using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Network.DTO;
using Network.DTO.Application;
using Network.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly DepartmentRepository departmentRepository;
        private readonly IApplicationService applicationService;
        private readonly OperatorRepository operatorRepository;
        private readonly TariffRepository tariffRepository;
        public MainController(UserManager<User> userManager, DepartmentRepository departmentRepository, OperatorRepository operatorRepository,TariffRepository tariffRepository, IApplicationService applicationService)
        {
            this.userManager = userManager;
            this.operatorRepository = operatorRepository;
            this.tariffRepository = tariffRepository;
            this.departmentRepository = departmentRepository;
            this.applicationService = applicationService;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddApplication()
        {
            var model = new AddApplicationViewModel
            {
                Departments = await departmentRepository.GetDepartmentList(),
                Operators = await operatorRepository.GetOperatorList(),
                Tariffs = await tariffRepository.GetTariffList()
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddApplication(AddApplicationViewModel model)
        {
            await applicationService.CreateAsync(model);
            return View();
        }
    }
}
