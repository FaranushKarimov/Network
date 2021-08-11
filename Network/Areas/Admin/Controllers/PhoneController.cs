using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Network.DTO.PhoneNumber;
using Network.Repository;
using Network.Services.Operator;
using Network.Services.PhoneNumber;
using Network.Services.Tariff;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Controllers
{
    [Area("Admin")] 
    public class PhoneController : Controller
    {
        private readonly ITariffService _tariffService;
        private readonly IOperatorService _operatorService;
        private readonly IPhoneService _phoneService;
        private readonly OperatorRepository _operatorRepository;
        private readonly TariffRepository _tariffRepository;

        public PhoneController(ITariffService tariffService,IOperatorService operatorService,OperatorRepository operatorRepository,TariffRepository tariffRepository,IPhoneService phoneService)
        {
            _tariffService = tariffService;
            _operatorService = operatorService;
            _operatorRepository = operatorRepository;
            _tariffRepository = tariffRepository;
            _phoneService = phoneService;
        }

        [Authorize]
        public async Task<JsonResult> GetTariffs()
        {
            var tariffs = await _tariffService.GetTariffAsync();
            return Json(JsonConvert.SerializeObject(tariffs));
        }

        [Authorize]
        public async Task<JsonResult> GetOperators()
        {
            var operators = await _operatorService.GetOperatorAsync();
            return Json(JsonConvert.SerializeObject(operators));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddPhoneNumber()
        { 
            var phoneViewModel = new AddPhoneViewModel();
            phoneViewModel.Operators = await _operatorRepository.GetOperatorList();
            phoneViewModel.Tariffs = await _tariffRepository.GetTariffList();
            return View(phoneViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPhoneNumber(AddPhoneViewModel model)
        {
            if(!ModelState.IsValid)
            {
                model.Operators = await _operatorRepository.GetOperatorList();
                model.Tariffs = await _tariffRepository.GetTariffList();
                return View(model);
            }
            await _phoneService.Create(model);
            return Redirect("");

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
