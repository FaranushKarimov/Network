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
        private readonly IMapper _mapper;
        public PhoneService(PhoneNumberRepository phoneNumberRepository,IMapper mapper,TariffRepository tariffRepository)
        {
            _phoneNumberRepository = phoneNumberRepository;
            _tariffRepository = tariffRepository;
            _mapper = mapper;
        }
        public async Task<Domain.Models.PhoneNumber> Create(AddPhoneViewModel addPhoneViewModel)
        {
            var tariff = _tariffRepository.Entities.FirstOrDefault(x => x.Id == addPhoneViewModel.TariffId);
            if (tariff != null)
            {
                var model = new Domain.Models.PhoneNumber
                {
                    TelephoneNumber = addPhoneViewModel.PhoneNumber,
                    TariffId = addPhoneViewModel.TariffId,
                    OperatorId = tariff.OperatorId
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
    }
}
