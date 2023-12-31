﻿namespace Database
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; }  = null!;
        public virtual List<Vacancy> Vacancies { get; set; } = new List<Vacancy>();

    }
}