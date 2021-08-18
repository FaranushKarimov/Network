using Domain.Models;
using Network.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Repository
{
    public class UserRepository : GenericRepository<DataContext,User,int>
    {
        public UserRepository(DataContext context) : base(context)
        {

        }
    }
}
