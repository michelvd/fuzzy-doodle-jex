using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Database
{
    public class CoreContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public CoreContext(DbContextOptions<CoreContext> options)
        : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable("companies");
            modelBuilder.Entity<Vacancy>().ToTable("vacancies");

            modelBuilder.Entity<Company>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Company>()
                .Property(b => b.Name)
                .IsRequired();

            modelBuilder.Entity<Company>()
                .Property(b => b.Address)
                .IsRequired();

            modelBuilder.Entity<Vacancy>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Vacancy>()
                .Property(v => v.Title)
                .IsRequired();

            modelBuilder.Entity<Vacancy>()
                .Property(v => v.Description);

            
            modelBuilder.Entity<Vacancy>()
                .HasOne(v => v.Company)
                .WithMany(b => b.Vacancies)
                .HasForeignKey(v => v.CompanyId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
