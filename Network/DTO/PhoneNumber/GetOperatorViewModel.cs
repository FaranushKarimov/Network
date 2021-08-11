using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.DTO.PhoneNumber
{
    public class GetOperatorViewModel
    {
        public int OperatorId { get; set; }
        public string OperatorName { get; set; }
        public List<GetTariffViewModel> Tariffs { get; set; }
    }
}
