using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Pages
{
    public class EmployeeListBase : ComponentBase
    {

        [Inject]
        public ApplicationDbContext Db { get; set; }
        public bool ShowFooter { get; set; } = true;
        public IEnumerable<Employee> Employees { get; set; }

        protected override void OnInitialized()
        {
            Employees = Db.Users.ToList();
        }
        protected void EmployeeDeleted()
        {
            Employees = Db.Users.ToList();
        }
        
    }
}