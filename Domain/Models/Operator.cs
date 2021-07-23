using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Operator
    {
        public int Id { get; set; }
        public string OperatorName { get; set; } 
        public virtual ICollection<Tariff> Tariffs { get; set; }
    }
}
