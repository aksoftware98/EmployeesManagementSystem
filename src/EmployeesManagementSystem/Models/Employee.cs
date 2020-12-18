using EmployeesManagementSystem.Models.CustomValidators;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeesManagementSystem.Models
{
   public class Employee : IdentityUser
    {
        [Required(ErrorMessage = "Please provide first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please provide surname")]
        [MinLength(2)]
        public string LastName { get; set; }
      
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string PhotoPath { get; set; }
        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }

    }
}
