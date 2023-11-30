using Database;

namespace WebApi.Repositories
{
    public interface ICompaniesRepository
    {
        void DeleteById(int id);
        List<Company> GetAll(bool onlyWithVacancies);
        Company? GetById(int id);
        void Insert(Company company);
        void Update(Company company);
    }
}