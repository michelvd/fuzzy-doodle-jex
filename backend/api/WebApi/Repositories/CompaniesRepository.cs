using Database;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repositories
{
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

        public List<Company> GetAll(bool onlyWithVacancies)
        {
            var companies = _context.Companies.AsQueryable(); 
            if (onlyWithVacancies)
            {
                companies = companies.Where(c => c.Vacancies.Any());
            }
            companies = companies.Include(c => c.Vacancies);
            return companies.ToList();
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