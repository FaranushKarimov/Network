using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Network.Data;
using System;
using System.Collections.Generic;  
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Repository
{
    public class DepartmentRepository : GenericRepository<DataContext,Department,int>
    {
        public DepartmentRepository(DataContext context) : base(context)
        {

        }
        public async Task<List<SelectListItem>> GetDepartmentList()
        {
            return await context.Departments.Select(x => new SelectListItem { Text = x.DepartmentName, Value = x.DepartmentId.ToString() }).ToListAsync();
        }
    }
}
