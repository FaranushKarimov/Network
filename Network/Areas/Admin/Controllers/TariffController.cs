using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Network.DTO.Tariff;
using Network.Repository;
using Network.Services.Tariff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TariffController : Controller
    {
        private readonly ITariffService _tariffService;
        private readonly OperatorRepository _operatorRepository;

        public TariffController(ITariffService tariffService, OperatorRepository operatorRepository)
        {
            _tariffService = tariffService;
            _operatorRepository = operatorRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddTariff()
        {
            var tariffViewModel = new CreateTariffViewModel();
            tariffViewModel.Operators = await _operatorRepository.GetOperatorList();
            return View(tariffViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTariff(CreateTariffViewModel tariffViewModel)
        {
            if(!ModelState.IsValid)
            {
                tariffViewModel.Operators = await _operatorRepository.GetOperatorList();
                return View(tariffViewModel);
            }
            await _tariffService.Create(tariffViewModel);
            return Redirect("/Admin/Tariff/GetTariffs");   
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetTariffs()
        {
            var tariffs = await _tariffService.GetAllTariffs();
            return View(tariffs);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditTariff(UpdateTariffViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            await _tariffService.Update(model);
            return Redirect("/Admin/Tariff/GetTariffs");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditTariff(int id)
        {
            var tariff = await _tariffService.GetByTariffId(id);
            return View(tariff);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> DeleteTariff(int id)
        {
            await _tariffService.Delete(id);
            return Redirect("/Admin/Tariff/GetTariffs");
        }
    }
}
