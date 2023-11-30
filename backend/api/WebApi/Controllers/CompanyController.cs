using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        public List<CompanyDto> Get()
        {
            return _companiesRepository.GetAll().Select(x => new CompanyDto(x.Id, x.Name, x.Address)).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Company? company = _companiesRepository.GetById(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch([FromBody] CompanyPatchDto companyPatchDto, int id)
        {
            Company? company = _companiesRepository.GetById(id);
            if (company == null)
            {
                return NotFound();
            }
            // should check if companyPatchDto is valid
            Company patchedCompany = new()
            {
                Address = companyPatchDto.Address,
                Name = companyPatchDto.Name,
                Id = id
            };
            _companiesRepository.Update(patchedCompany);

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


            var company = _companiesRepository.GetById(id);
            if (company == null)
            {
                return NotFound();
            }
            _companiesRepository.DeleteById(id);

            return NoContent();
        }
    }
    [ApiController]
    [Route("companies")]
    public class VacancyController : ControllerBase
    {
        private readonly IVacanciesRepository _vacanciesRepository;

        public VacancyController(IVacanciesRepository vacanciesRepository)
        {
            _vacanciesRepository = vacanciesRepository;
        }

        [HttpGet("{companyId}/vacancies")]
        public List<VacanyDto> Get(int companyId)
        {
            return _vacanciesRepository.GetAll(companyId).Select(x => new VacanyDto { Id = x.Id, Title = x.Title, Description = x.Description }).ToList();
        }

        [HttpGet("{companyId}/vacancies/{id}")]
        public IActionResult GetById(int id, int companyId)
        {
            Vacancy? vacancy = _vacanciesRepository.GetById(id);
            if (vacancy == null)
            {
                return NotFound();
            }
            return Ok(new VacancyDto { CompanyId = vacancy.Id, Description  =   vacancy.Description, Id = vacancy.Id, Title = vacancy.Title});
        }

        [HttpPost("{companyId}/vacancies")]
        public IActionResult Post([FromBody] VacancyPostDto vacancyPostDto, int companyId)
        {

            // should check if vacancyPostDto is valid
            Vacancy vacancy = new()
            {
                Title = vacancyPostDto.Title,
                Description = vacancyPostDto.Description,
                CompanyId = companyId
            };
            _vacanciesRepository.Insert(vacancy);

            // moet eigenlijk een 201 created zijn met een locatie er bij
            return Ok();
        }
    }

    public interface IVacanciesRepository
    {
        IEnumerable<Vacancy> GetAll(int companyId);
        Vacancy? GetById(int id);
        void Insert(Vacancy vacancy);
    }
    public class VacanciesRepository : IVacanciesRepository
    {
        private readonly CoreContext _context;

        public VacanciesRepository(CoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Vacancy> GetAll(int companyId)
        {
            return _context.Vacancies.AsNoTracking().Where(x => x.CompanyId == companyId).ToList();
        }

        public Vacancy? GetById(int id)
        {
            Vacancy? vacancy = _context.Vacancies.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return vacancy;

        }

        public void Insert(Vacancy vacancy)
        {
            var toInsert = new Vacancy
            {
                Title = vacancy.Title,
                Description = vacancy.Description,
                CompanyId = vacancy.CompanyId
            };
            _context.Vacancies.Add(toInsert);
            _context.Entry(toInsert).State = EntityState.Added;
            _context.SaveChanges();
        }
    }
    public class VacanyDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; } = null!;
    }  
    
    public class VacancyPostDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
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
        public string? Description { get; set; } = null!;
        public int CompanyId { get; set; }
    }

    // zolang alles in 1 file, dat werkt gemakkelijker, later alles even splitsen
    public interface ICompaniesRepository
    {
        void DeleteById(int id);
        List<Company> GetAll();
        Company? GetById(int id);
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

        public List<Company> GetAll()
        {
            return _context.Companies.AsNoTracking().ToList();
        }

        public Company? GetById(int id)
        {
            Company? company = _context.Companies.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return company;
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