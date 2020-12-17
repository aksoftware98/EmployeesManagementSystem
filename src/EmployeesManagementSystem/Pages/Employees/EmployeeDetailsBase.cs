using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();
        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public ApplicationDbContext Db { get; set; }
        [Parameter]
        public int Id { get; set; }
        protected External.Components.ConfirmBase DeleteConfirmation { get; set; }
        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                Db.Employees.Remove(Employee);
                await Db.SaveChangesAsync();
                await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
            }
        }

        protected override void OnInitialized()
        {
            Employee = Db.Employees.Find(Id);
        }

    }
}
