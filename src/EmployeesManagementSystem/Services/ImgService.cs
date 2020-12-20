using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesManagementSystem.Data;

namespace EmployeesManagementSystem.Services
{
    public class ImgService
    {
        private readonly ApplicationDbContext _dbcontext;
        public ImgService(ApplicationDbContext _db)
        {
            _dbcontext = _db;
        }
    }
}
