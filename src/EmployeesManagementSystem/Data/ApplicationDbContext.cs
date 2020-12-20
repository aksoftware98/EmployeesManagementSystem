using EmployeesManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<PhotoPath> SaveImg { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasMany(d => d.Employees).WithOne(e => e.Department); // One to many 


            base.OnModelCreating(modelBuilder);

            // Seed Department Table
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(
    new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
    new Department { DepartmentId = 3, DepartmentName = "Adminstration" });
            modelBuilder.Entity<Department>().HasData(
    new Department { DepartmentId = 4, DepartmentName = "Admin" });

           
        }
    }
}
