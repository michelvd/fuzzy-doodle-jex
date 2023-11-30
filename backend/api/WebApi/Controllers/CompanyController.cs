using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    public class VacancyDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CompanyId { get; set; }
    }
    // zolang alles in 1 file, dat werkt gemakkelijker, later alles even splitsen
    public interface ICompaniesRepository { 
        List<CompanyDto> GetAll();
    }
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly CoreContext _context;

        public CompaniesRepository(CoreContext context)
        {
            _context = context;
        }

        public List<CompanyDto> GetAll()
        {
            return _context.Companies.AsNoTracking().Select(x => new CompanyDto(x.Id, x.Name, x.Address)).ToList(); 
        }
    }
}