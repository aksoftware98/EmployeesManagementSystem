using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models.DataSeeding
{
    public class UsersSeeding
    {

        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersSeeding(UserManager<Employee> userManager,
                            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedData()
        {
            if (await _roleManager.FindByNameAsync("Admin") != null)
                return;

            // Create role 
            var adminRole = new IdentityRole { Name = "Admin" };
            await _roleManager.CreateAsync(adminRole);

            var userRole = new IdentityRole { Name = "User" };
            await _roleManager.CreateAsync(userRole);

            var itRole = new IdentityRole { Name = "IT" };
            await _roleManager.CreateAsync(itRole);

            var teamLeaderRole = new IdentityRole { Name = "Team Leader" };
            await _roleManager.CreateAsync(teamLeaderRole);

            // Create admin 
            var admin = new Employee
            {
                Email = "admin@test.com",
                UserName = "admin@dotnetlabs.com",
                FirstName = "Admin",
                LastName = "Admin",
                Gender = Gender.Mężczyzna,
                DateOfBirth = new DateTime(1990, 01, 01), 
                DepartmentId = 4,
            };
            await _userManager.CreateAsync(admin, "Test.123");
            await _userManager.AddToRoleAsync(admin, "Admin");

            // Create user 
            var hrUser = new Employee
            {
                Email = "hr@test.com",
                UserName = "hr@dotnetlabs.com",
                FirstName = "HR",
                LastName = "HR",
                Gender = Gender.Kobieta,
                DateOfBirth = new DateTime(1996, 01, 01),
                DepartmentId = 2,
            };
            await _userManager.CreateAsync(hrUser, "Test.123");
            await _userManager.AddToRoleAsync(hrUser, "User");

            // Create team leader 
            var teamLeaderUser = new Employee
            {
                Email = "teamleader@test.com",
                UserName = "teamleader@dotnetlabs.com",
                FirstName = "Team",
                LastName = "Leader",
                Gender = Gender.Kobieta,
                DateOfBirth = new DateTime(1992, 01, 01),
                DepartmentId = 2,
            };
            await _userManager.CreateAsync(teamLeaderUser, "Test.123");
            await _userManager.AddToRoleAsync(teamLeaderUser, "User");

            // Create IT 
            var itUser = new Employee
            {
                Email = "it@test.com",
                UserName = "it@dotnetlabs.com",
                FirstName = "IT",
                LastName = "Leader",
                Gender = Gender.Mężczyzna,
                DateOfBirth = new DateTime(1991, 01, 01),
                DepartmentId = 1,
            };
            await _userManager.CreateAsync(itUser, "Test.123");
            await _userManager.AddToRoleAsync(itUser, "User");


        }

    }
}
