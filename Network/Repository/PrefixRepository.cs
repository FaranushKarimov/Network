using Network.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Repository
{
    public class PrefixRepository: GenericRepository<DataContext, Domain.Models.Prefix, int>
    { 
            public PrefixRepository(DataContext context) : base(context)
            {

            }
    }
}
