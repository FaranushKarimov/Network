using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Tariff
    {
        public int Id { get; set; }
        public string TariffName { get; set;  }
        public int OperatorId { get; set; }
        public virtual Operator Operator { get; set; }
    }
}
