using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Network.DTO.PhoneNumber;
using Network.DTO.Tariff;
using Network.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace Network.Services.Tariff
{
    public class TariffService : ITariffService
    {
        private readonly IMapper _mapper;
        private readonly TariffRepository _tariffRepository;
        private readonly OperatorRepository _operatorRepository;

        public TariffService(TariffRepository tariffRepository, IMapper mapper, OperatorRepository operatorRepository)

        {
            _tariffRepository = tariffRepository;
            _operatorRepository = operatorRepository;
            _mapper = mapper;
        }
        public async Task<Domain.Models.Tariff> Create(CreateTariffViewModel tariff)
        {
            var model = new Domain.Models.Tariff
            {
                TariffName = tariff.TariffName,
                OperatorId = tariff.OperatorId
            };
            return await _tariffRepository.Create(model);
        }

        public async Task Delete(int tariffid)
        {
            var exist = await _tariffRepository.Get(tariffid);
            if (exist == null)
            {
                return;
            }
            await _tariffRepository.Delete(exist);
        }

        public async Task EditTariff(UpdateTariffViewModel tariff)
        {
            var editTariff = _mapper.Map<Domain.Models.Tariff>(tariff);
            await _tariffRepository.Update(editTariff);
        }

        public async Task<List<TariffViewModel>> GetAllTariffs()
        {
            return await _tariffRepository.Entities.Include(x => x.Operator).Select(x => new TariffViewModel { TariffId = x.Id, OperatorName = x.Operator.OperatorName, TariffName = x.TariffName }).ToListAsync();
        }

        public async Task<UpdateTariffViewModel> GetByTariffId (int id)
        {
            var tariff = await _tariffRepository.Get(id);
            return new UpdateTariffViewModel
            {
                TariffId = tariff.Id,
                TariffName = tariff.TariffName,
                OperatorId = tariff.OperatorId,
                Operators = await _operatorRepository.GetOperatorList()
            };
            
        }

        public async Task Update(UpdateTariffViewModel model)
        {
            // var tariff = _mapper.Map<Domain.Models.Tariff>(model);
            var tariff = await _tariffRepository.Get(model.TariffId);
            tariff.OperatorId = model.OperatorId;
            tariff.TariffName = model.TariffName;
            await _tariffRepository.Update(tariff);
        }

        public async Task<List<GetTariffViewModel>> GetTariffAsync()
        {
            return await _tariffRepository.Entities.Select(x => new GetTariffViewModel
            {
                TariffId = x.Id,
                TariffName = x.TariffName,
                OperatorId = x.OperatorId
            }).ToListAsync();
        }
    }
}
