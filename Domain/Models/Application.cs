using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string ApplicationReason { get; set; }
        public DateTime CreatedAt { get; set; }
        public int StatusId { get; set; }
        public int TariffId { get; set; }

        //public string ManagerId { get; set; }
        //public virtual Manager Manager { get; set; }
        public virtual User User { get; set; }
        public virtual Tariff Tariff { get; set; }
    }
}
