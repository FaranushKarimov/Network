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
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
