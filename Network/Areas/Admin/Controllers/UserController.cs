using Microsoft.AspNetCore.Mvc;
using Network.Repository;
using Network.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly DepartmentRepository _departmentRepository;

        public UserController(IUserService userService,DepartmentRepository departmentRepository)
        {
            _userService = userService;
            _departmentRepository = departmentRepository;
        }
        public async Task<IActionResult> GetUsers()
        {
            var users =  await _userService.GetAllUsers();
            return View(users);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
