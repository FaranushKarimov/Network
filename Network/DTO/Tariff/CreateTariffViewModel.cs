using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.DTO.Tariff
{
    public class CreateTariffViewModel
    {
        public string TariffName { get; set; }
        public int OperatorId { get; set; }
        public List<SelectListItem> Operators { get; set; }
    }
}
