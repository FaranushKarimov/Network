using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Network.DTO.Account
{
    public class DepartmentViewModel
    {

        public int DepartmentId { get; set; }
        [Display(Name = "DepartmentName")]
        public string DepartmentName { get; set; }
    }
}
