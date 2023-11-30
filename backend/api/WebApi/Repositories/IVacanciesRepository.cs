using Database;

namespace WebApi.Repositories
{
    public interface IVacanciesRepository
    {
        IEnumerable<Vacancy> GetAll(int companyId);
        Vacancy? GetById(int id);
        void Insert(Vacancy vacancy);
    }
}