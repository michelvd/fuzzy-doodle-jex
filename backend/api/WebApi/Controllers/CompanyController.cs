using Database;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using WebApi.DTO;
using WebApi.Repositories;
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
        public List<CompanyDto> Get([FromQuery] bool onlyWithVacancies)
        {
            return _companiesRepository.GetAll(onlyWithVacancies)
                .Select(x => new CompanyDto(x.Id, x.Name, x.Address, x.Vacancies.Select(v => new VacancyDto(v.Id, v.Title, v.Description, v.CompanyId)).ToList())).ToList();
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
}