namespace WebApi.DTO
{
    public class CompanyPatchDto
    {
        public CompanyPatchDto(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}