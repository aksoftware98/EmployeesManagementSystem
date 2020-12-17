using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using External.Components;
using EmployeesManagementSystem.Models;
using EmployeesManagementSystem.Data;

namespace EmployeesManagementSystem.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }
        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }
        [Parameter]
        public EventCallback<string> OnEmployeeDeleted { get; set; }
        [Inject]
        public ApplicationDbContext Db { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected External.Components.ConfirmBase DeleteConfirmation { get; set; }
        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                Db.Users.Remove(Employee);
                await Db.SaveChangesAsync(); 
                await OnEmployeeDeleted.InvokeAsync(Employee.Id);
            }
        }

        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            await OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }
    }
}
