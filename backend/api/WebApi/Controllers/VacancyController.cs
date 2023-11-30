using Database;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;
using WebApi.Repositories;

namespace WebApi.Controllers
{
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
            return Ok(new VacancyDto(vacancy.Id,vacancy.Title, vacancy.Description, vacancy.CompanyId));
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
}