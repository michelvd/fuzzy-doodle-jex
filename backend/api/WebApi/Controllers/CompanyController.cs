using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("companies")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompaniesRepository _companiesRepository;

        public CompanyController(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        [HttpGet]
        public IEnumerable<CompanyDto> Get()
        {
            return _companiesRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            CompanyDto company = _companiesRepository.GetById(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch([FromBody] CompanyPatchDto companyPatchDto, int id)
        {
            CompanyDto companyDto = _companiesRepository.GetById(id);
            if (companyDto == null)
            {
                return NotFound();
            }
            // should check if companyPatchDto is valid
            Company company = new()
            {
                Address = companyPatchDto.Address,
                Name = companyPatchDto.Name,
                Id = id
            };
            _companiesRepository.Update(company);

            return NoContent();
        }

        [HttpPost()]
        public IActionResult Post([FromBody] CompanyPostDto companyPostDto)
        {

            // should check if companyPostDto is valid
            Company company = new()
            {
                Address = companyPostDto.Address,
                Name = companyPostDto.Name,
            };
            _companiesRepository.Insert(company);

            // moet eigenlijk een 201 created zijn met een locatie er bij
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {


            CompanyDto companyDto = _companiesRepository.GetById(id);
            if (companyDto == null)
            {
                return NotFound();
            }
            _companiesRepository.DeleteById(id);

            return NoContent();
        }
    }
    public class CompanyDto
    {
        public CompanyDto(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public virtual List<VacancyDto> Vacancies { get; set; } = new List<VacancyDto>();
    }


    public class CompanyPatchDto
    {
        public CompanyPatchDto(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
       public class CompanyPostDto
    {
        public CompanyPostDto(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
    }

    public class VacancyDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CompanyId { get; set; }
    }

    // zolang alles in 1 file, dat werkt gemakkelijker, later alles even splitsen
    public interface ICompaniesRepository
    {
        void DeleteById(int id);
        List<CompanyDto> GetAll();
        CompanyDto GetById(int id);
        void Insert(Company company);
        void Update(Company company);
    }
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly CoreContext _context;

        public CompaniesRepository(CoreContext context)
        {
            _context = context;
        }

        public void DeleteById(int id)
        {
            Company? company = _context.Companies.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (company == null)
            {
                throw new ApplicationException($"Company {id} not found");
            }
            _context.Remove(company);
            _context.SaveChanges();
        }

        public List<CompanyDto> GetAll()
        {
            return _context.Companies.AsNoTracking().Select(x => new CompanyDto(x.Id, x.Name, x.Address)).ToList();
        }

        public CompanyDto GetById(int id)
        {
            Company? company = _context.Companies.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return company == null ? null! : new CompanyDto(company.Id, company.Name, company.Address);
        }


        public void Insert(Company company)
        {
            var toInsert = new Company
            {
                Address = company.Address,
                Name = company.Name,
            };
            _context.Companies.Add(toInsert);
            _context.Entry(toInsert).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(Company company)
        {
            Company? existingCompany = _context.Companies.FirstOrDefault(x => x.Id == company.Id);
            if (existingCompany == null)
            {
                throw new ApplicationException($"Company {company.Id} not found");
            }
            existingCompany.Name = company.Name;
            existingCompany.Address = company.Address;
            _context.SaveChanges();
        }
    }
}