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
    public class TariffRepository : GenericRepository<DataContext,Tariff,int>
    {
        public TariffRepository(DataContext context) : base(context)
        {

        }
        public async Task<List<SelectListItem>> GetTariffList()
        {
            return await context.Tariffs.Select(x => new SelectListItem { Text = x.TariffName, Value = x.Id.ToString() }).ToListAsync();
        }
    }
}
