using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.DTO.Application
{
    public class AddApplicationViewModel
    {
        public int ManagerId { get; set; }
        public string FullName { get; set; }
        public int DepartmentId { get; set; }
        public string ApplicationReason { get; set; }
        public int OperatorId { get; set; }
        public int TariffId { get; set; }
        public List<SelectListItem> Departments { get; set; }
        public List<SelectListItem> Operators { get; set; }
        public List<SelectListItem> Tariffs { get; set; }
    }
}
