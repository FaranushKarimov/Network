using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public string ApplicationReason { get; set; }
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
