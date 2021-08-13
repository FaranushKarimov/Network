using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.DTO.PhoneNumber
{
    public class PhoneNumberViewModel
    {
        public int PhoneNumberId { get; set; }
        public string PhoneNumber { get; set; }
        public string TariffName { get; set; }
        public string OperatorName { get; set; }
    }
}
