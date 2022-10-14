using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<GithubProfile> GithubProfiles { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration):base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if(!optionsBuilder.IsConfigured)
            //{
            //    base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("MSSQLServer")));
            //}
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(p =>
            {
                p.ToTable("ProgrammingLanguages").HasKey(p => p.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
            });
            modelBuilder.Entity<Technology>(t =>
            {
                t.ToTable("ProgrammingLanguageTechnologies").HasKey(t => t.Id);
                t.Property(t => t.Id).HasColumnName("Id");
                t.Property(t => t.Name).HasColumnName("Name");
                t.Property(t => t.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                t.HasOne(t => t.ProgrammingLanguage);
            });
            modelBuilder.Entity<GithubProfile>(g =>
            {
                g.ToTable("GithubProfiles").HasKey(g => g.Id);
                g.Property(g => g.Id).HasColumnName("Id");
                g.Property(g => g.UserId).HasColumnName("UserId");
                g.Property(g => g.Github).HasColumnName("GithubUrl");
                g.HasOne(g => g.User);
            });
            ProgrammingLanguage[] languagesSeedData = { new(1, "Java"), new(2, "C#"), new(3, "Python") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(languagesSeedData);
            Technology[] technologiesSeedData = { new(1, 1, "Java"), new(2, 1, "Asp.Net Core"), new(3, 1, "Django") }; 
            modelBuilder.Entity<Technology>().HasData(technologiesSeedData);

           
        }

    }
}
