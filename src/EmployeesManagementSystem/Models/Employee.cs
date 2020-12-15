using EmployeesManagementSystem.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeesManagementSystem.Models
{
   public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="Proszę podać imię")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwisko")]
        [MinLength(2)]
        public string LastName { get; set; }
        [EmailAddress]
        [EmailDomainValidator(AllowedDomain ="gmail.com", ErrorMessage ="Domena musi być gmail.com")]
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }

    }
}
