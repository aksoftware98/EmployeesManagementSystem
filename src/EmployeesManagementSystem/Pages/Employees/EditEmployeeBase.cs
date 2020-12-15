using AutoMapper;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Pages
{
    [Authorize]
    public class EditEmployeeBase : ComponentBase
    {

        [Inject]
        public ApplicationDbContext Db { get; set; }

        public string PageHeaderText { get; set; }

        private Employee Employee { get; set; } = new Employee();

        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();


        public List<Department> Departments { get; set; } = new List<Department>();

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            //var authenticationState = await AuthenticationStateTask;
            //if (!authenticationState.User.Identity.IsAuthenticated)
            //{
            //    string returnUrl = WebUtility.UrlEncode($"/editEmployee/{Id}");
            //    NavigationManager.NavigateTo($"/identity/account/login?returnUrl={returnUrl}");
            //}

            int.TryParse(Id, out int employeeId);
            if (employeeId != 0)
            {
                PageHeaderText = "Edytuj pracownika";
                Employee = Db.Employees.Find(Convert.ToInt32(Id));
            }
            else
            {
                PageHeaderText = "Nowy pracownik";
                Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/nophoto.jpg"
                };
            }


            Departments = Db.Departments.ToList();
            Mapper.Map(Employee, EditEmployeeModel);
        }

        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditEmployeeModel, Employee);

            //Employee result = null;

            Mapper.Map(EditEmployeeModel, Employee);
            if (Employee.EmployeeId != 0)
            {
                await Db.SaveChangesAsync();
            }
            else
            {
                Db.Employees.Add(Employee);
                await Db.SaveChangesAsync();
            }

            NavigationManager.NavigateTo("/");

        }
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
                NavigationManager.NavigateTo("/");
            }
        }

    }
}