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
using Microsoft.AspNetCore.Identity;

namespace EmployeesManagementSystem.Pages
{
    [Authorize]
    public class EditEmployeeBase : ComponentBase
    {

        [Inject]
        public ApplicationDbContext Db { get; set; }

        [Inject] public UserManager<Employee> UserManager { get; set; }

        public string PageHeaderText { get; set; }

        private Employee Employee { get; set; } = new Employee();

        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();


        public List<Department> Departments { get; set; } = new List<Department>();

        [Parameter]
        public string Id { get; set; }

        private bool IsAdd => string.IsNullOrWhiteSpace(Id);

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //var authenticationState = await AuthenticationStateTask;
            //if (!authenticationState.User.Identity.IsAuthenticated)
            //{
            //    string returnUrl = WebUtility.UrlEncode($"/editEmployee/{Id}");
            //    NavigationManager.NavigateTo($"/identity/account/login?returnUrl={returnUrl}");
            //}

            if (!string.IsNullOrWhiteSpace(Id))
            {
                PageHeaderText = "Edytuj pracownika";
                Employee = await UserManager.FindByIdAsync(Id);
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
            if (!IsAdd)
            {
                await Db.SaveChangesAsync();
            }
            else
            {
                //Employee.Id = null;
                Employee.PasswordHash = null;
                Employee.UserName = Employee.Email;
                var result = await UserManager.CreateAsync(Employee, EditEmployeeModel.Password); 
            }

            NavigationManager.NavigateTo("employeelist");

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
                Db.Users.Remove(Employee);
                await Db.SaveChangesAsync();
                NavigationManager.NavigateTo("employeelist");
            }
        }

    }
}