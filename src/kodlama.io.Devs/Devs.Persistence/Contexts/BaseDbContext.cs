using Core.Security.Entities;
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
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }



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
            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(c => c.FirstName).HasColumnName("FirstName");
                a.Property(c => c.LastName).HasColumnName("LastName");
                a.Property(c => c.Email).HasColumnName("Email");
                a.Property(c => c.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(c => c.PasswordHash).HasColumnName("PasswordHash");
                a.Property(c => c.Status).HasColumnName("Status");
                a.Property(c => c.AuthenticatorType).HasColumnName("AuthenticatorType");

                a.HasMany(c => c.UserOperationClaims);
                a.HasMany(c => c.RefreshTokens);
            });
            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(c => c.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(c => c.UserId).HasColumnName("UserId");
                a.Property(c => c.OperationClaimId).HasColumnName("OperationClaimId");

                a.HasOne(c => c.OperationClaim);
                a.HasOne(c => c.User);
            });

            //ProgrammingLanguage[] languagesSeedData = { new(1, "Java"), new(2, "C#"), new(3, "Python") };
            //modelBuilder.Entity<ProgrammingLanguage>().HasData(languagesSeedData);
            //Technology[] technologiesSeedData = { new(1, 1, "Java"), new(2, 1, "Asp.Net Core"), new(3, 1, "Django") }; 
            //modelBuilder.Entity<Technology>().HasData(technologiesSeedData);

           
        }

    }
}
