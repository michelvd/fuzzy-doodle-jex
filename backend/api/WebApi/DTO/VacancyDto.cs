﻿namespace WebApi.DTO
{
    public class VacancyDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public int CompanyId { get; set; }
    }
}