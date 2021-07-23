using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public  class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
    }
}
