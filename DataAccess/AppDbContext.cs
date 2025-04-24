using BootCampProject.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
namespace DataAccess.Contexts // veya BootCampProject.WebAPI.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TPH (Table per Hierarchy) default olarak kullanılır
            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<User>("User")
                .HasValue<Instructor>("Instructor")
                .HasValue<Applicant>("Applicant")
                .HasValue<Employee>("Employee");
        }
    }
}