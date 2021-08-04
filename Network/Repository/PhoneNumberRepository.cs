using Domain.Models;
using Network.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Repository
{
    public class PhoneNumberRepository: GenericRepository<DataContext,PhoneNumber,int>
    {
       public PhoneNumberRepository(DataContext context) : base(context)
       {

       }

    }
}
