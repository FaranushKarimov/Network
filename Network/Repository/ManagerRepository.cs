using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Network.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Repository
{
    public class ManagerRepository : GenericRepository<DataContext,Manager,int>
    {
        public ManagerRepository(DataContext context) : base(context)
        {

        }
        
        public async Task<List<SelectListItem>> GetManagerList()
        {
            return await context.Managers.Select(x => new SelectListItem { Text = x.ManagerName, Value = x.Id.ToString() }).ToListAsync();
        }

    }
}
