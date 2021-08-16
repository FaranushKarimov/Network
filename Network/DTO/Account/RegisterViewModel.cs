using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Network.DTO.Account
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int DepartmentId { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public List<SelectListItem> Departments { get; set; }
    }
}
