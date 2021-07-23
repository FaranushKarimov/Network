using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Role:IdentityRole
    {
        public Role() { }
        public Role(string name):base(name) { }
        public string Translate { get; set; }
    }
}
