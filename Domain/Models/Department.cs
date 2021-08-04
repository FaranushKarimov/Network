using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public  class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
   //     public DateTime CreatedAt { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
    }
}
