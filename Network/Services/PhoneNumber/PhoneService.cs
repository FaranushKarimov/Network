using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Network.DTO.PhoneNumber;
using Network.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Services.PhoneNumber
{
    public class PhoneService : IPhoneService
    {
        private readonly PhoneNumberRepository _phoneNumberRepository;
        private readonly TariffRepository _tariffRepository;
        private readonly OperatorRepository _operatorRepository;
        private readonly PrefixRepository _prefixRepository;
        private readonly IMapper _mapper;
        public PhoneService(PhoneNumberRepository phoneNumberRepository,IMapper mapper,TariffRepository tariffRepository,OperatorRepository operatorRepository, PrefixRepository prefixRepository)
        {
            _operatorRepository = operatorRepository;
            _phoneNumberRepository = phoneNumberRepository;
            _tariffRepository = tariffRepository;
            _mapper = mapper;
            _prefixRepository = prefixRepository;
        }
        public async Task<Domain.Models.PhoneNumber> Create(AddPhoneViewModel addPhoneViewModel)
        {
            var prefix = _prefixRepository.Entities.FirstOrDefault(x => x.PrefixNumber == int.Parse(string.Join("", addPhoneViewModel.PhoneNumber.Where(Char.IsDigit).Skip(3).Take(2))));
             var tariff = _tariffRepository.Entities.FirstOrDefault(x => x.Id == addPhoneViewModel.TariffId);
            if (tariff != null && prefix != null)
            {
                var model = new Domain.Models.PhoneNumber
                {
                    TelephoneNumber = addPhoneViewModel.PhoneNumber,
                    TariffId = addPhoneViewModel.TariffId,
                    OperatorId = tariff.OperatorId,
                    PrefixId = prefix.PrefixId
                };
                var result = await _phoneNumberRepository.Create(model);
                return result;
            }
            
            return null;
        }

        public Task<List<PhoneNumberViewModel>> GetAllPhones()
        {
            return _phoneNumberRepository.Entities.Include(x => x.Operator).Include(x => x.Tariff).Select(x => new PhoneNumberViewModel { PhoneNumberId = x.Id, OperatorName = x.Operator.OperatorName, TariffName = x.Tariff.TariffName, PhoneNumber = x.TelephoneNumber }).ToListAsync();
        }

        public async Task<UpdatePhoneNumberViewModel> GetByPhoneId(int id)
        {
            var phone = await _phoneNumberRepository.Get(id);
            return new UpdatePhoneNumberViewModel
            {
                PhoneNumberId = phone.Id,
                TariffId = phone.TariffId,
                OperatorId = phone.OperatorId,
                Tariffs = await _tariffRepository.GetTariffList(),
                Operators = await _operatorRepository.GetOperatorList()
            };
        }

        public async Task Update(UpdatePhoneNumberViewModel model)
        {
            var phone = await _phoneNumberRepository.Get(model.PhoneNumberId);
            phone.OperatorId = model.OperatorId;
            phone.TariffId = model.TariffId;
            phone.TelephoneNumber = model.PhoneNumber;
            await _phoneNumberRepository.Update(phone);
        }
    }
}
