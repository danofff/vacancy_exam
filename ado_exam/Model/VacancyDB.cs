namespace ado_exam.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class VacancyDB : DbContext
    {
        public VacancyDB()
            : base("name=VacanciesConnection")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }

    }
}