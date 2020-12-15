using EmployeesManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Department Table
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(
    new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
    new Department { DepartmentId = 3, DepartmentName = "Księgowość" });
            modelBuilder.Entity<Department>().HasData(
    new Department { DepartmentId = 4, DepartmentName = "Admin" });

            // Seed Employee Table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Dżon",
                LastName = "Trawolta",
                Email = "dzon@trawolta.com",
                DateOfBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Mężczyzna,
                DepartmentId = 1,
                PhotoPath = "images/dzon.png"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "Jam",
                LastName = "Łasica",
                Email = "jam@lasica.com",
                DateOfBirth = new DateTime(1920, 7, 3),
                Gender = Gender.Mężczyzna,
                DepartmentId = 2,
                PhotoPath = "images/jam.png"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Anna",
                LastName = "Doruch",
                Email = "anna@doruch.com",
                DateOfBirth = new DateTime(1999, 12, 24),
                Gender = Gender.Kobieta,
                DepartmentId = 3,
                PhotoPath = "images/anna.png"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                FirstName = "Ael",
                LastName = "Czikita",
                Email = "cos@fajnego.com",
                DateOfBirth = new DateTime(2010, 1, 1),
                Gender = Gender.Kobieta,
                DepartmentId = 4,
                PhotoPath = "images/konci.png"
            });
        }
    }
}
