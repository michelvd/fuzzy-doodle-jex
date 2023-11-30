namespace WebApi.DTO
{
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
}