using Database;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repositories
{
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
}