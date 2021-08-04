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
    public class OperatorRepository: GenericRepository<DataContext,Operator,int>
    {
        public OperatorRepository(DataContext context) : base(context)
        {

        }
        public async Task <List<SelectListItem>> GetOperatorList()
        {
            return await context.Operators.Select(x => new SelectListItem { Text = x.OperatorName, Value = x.Id.ToString() }).ToListAsync();
        }
    }
}
