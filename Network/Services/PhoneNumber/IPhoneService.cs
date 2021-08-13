using Network.DTO.PhoneNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Services.PhoneNumber
{
    public interface IPhoneService
    {
        Task<Domain.Models.PhoneNumber> Create(AddPhoneViewModel model);
        Task<List<PhoneNumberViewModel>> GetAllPhones();
    }
}
