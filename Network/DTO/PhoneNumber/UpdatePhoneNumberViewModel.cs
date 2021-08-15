﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.DTO.PhoneNumber
{
    public class UpdatePhoneNumberViewModel
    {
        public int PhoneNumberId { get; set; }
        public string PhoneNumber { get; set; }
        public int OperatorId { get; set; }
        public int TariffId { get; set;}
        public List<SelectListItem> Tariffs { get; set; }
        public List<SelectListItem> Operators { get; set; }
    }
}
