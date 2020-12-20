using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    public class PhotoPath
    {
        [Key]
        public int ImgId { get; set; }
        public string ImgName { get; set; }
        public byte[] Img { get; set; }
    }
}
