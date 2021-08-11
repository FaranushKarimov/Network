using AutoMapper;
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
        private readonly IMapper _mapper;
        public PhoneService(PhoneNumberRepository phoneNumberRepository,IMapper mapper)
        {
            _phoneNumberRepository = phoneNumberRepository;
            _mapper = mapper;
        }
        public async Task<Domain.Models.PhoneNumber> Create(AddPhoneViewModel addPhoneViewModel)
        {
            var model = new Domain.Models.PhoneNumber
            {
                TelephoneNumber = addPhoneViewModel.PhoneNumber,
                TariffId = addPhoneViewModel.TariffId
            };
            return await _phoneNumberRepository.Create(model);
        }
    }
}
