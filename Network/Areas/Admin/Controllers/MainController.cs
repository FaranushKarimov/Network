using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
