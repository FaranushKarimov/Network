﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string TelephoneNumber { get; set; }
        public int PrefixId { get; set; }
        public string UserId { get; set; }
        public int TariffId { get; set; }
        public virtual User User { get; set; }
    }
}
