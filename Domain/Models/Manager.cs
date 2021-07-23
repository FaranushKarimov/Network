using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string ManagerName { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
