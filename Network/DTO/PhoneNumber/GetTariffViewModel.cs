using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.DTO.PhoneNumber
{
    public class GetTariffViewModel
    {
         public int TariffId { get; set; }
         public string TariffName { get; set; }
         public int OperatorId { get; set; }
         public GetOperatorViewModel Operator { get; set; }
    }
}
