using Network.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Repository
{
    public class ApplicationRepository:GenericRepository<DataContext,Domain.Models.Application,int>
    {
        public ApplicationRepository(DataContext context) : base(context)
        {

        }
    }
}
