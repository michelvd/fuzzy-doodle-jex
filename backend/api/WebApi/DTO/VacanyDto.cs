namespace WebApi.DTO
{
    public class VacanyDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; } = null!;
    }
}