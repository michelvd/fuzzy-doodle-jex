namespace Database
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CompanyId { get; set; } 
        public Company Company { get; set; } = null!;
    }   
}