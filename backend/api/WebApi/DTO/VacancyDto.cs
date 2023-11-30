namespace WebApi.DTO
{
    public class VacancyDto
    {
        public VacancyDto(int id, string title, string? description, int companyId)
        {
            Id = id;
            Title = title;
            Description = description;
            CompanyId = companyId;
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public int CompanyId { get; set; }
    }
}