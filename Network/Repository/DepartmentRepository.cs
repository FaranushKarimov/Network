using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Network.Repository
{
    public class DepartmentRepository : GenericRepository<Data.DataContext,Department,int>
    {
        public DepartmentRepository(Data.DataContext context) : base(context)
        {
        }
    }
}
