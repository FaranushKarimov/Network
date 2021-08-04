using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class Prefix
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrefixId { get; set; }
        public int PrefixNumber { get; set; }
        public int OperatorId { get; set; }
        public virtual Operator Operator { get; set; }
    }
}
