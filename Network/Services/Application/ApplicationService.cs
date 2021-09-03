using AutoMapper;
using Network.DTO.Application;
using Network.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Network.DTO
{
    public class ApplicationService : IApplicationService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationRepository _applicationRepository;
     //   private readonly UserRepository _userRepository;
        private readonly TariffRepository _tariffRepository;

        public ApplicationService(IMapper mapper, ApplicationRepository applicationRepository)
        {
            _mapper = mapper;
            _applicationRepository = applicationRepository;
        }
        public async Task<Domain.Models.Application> CreateAsync(AddApplicationViewModel addApplicationViewModel, ClaimsPrincipal User)
        {
            //var model = _mapper.Map<Domain.Models.Application>(addApplicationViewModel);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var userName = User.FindFirstValue(ClaimTypes.Name);

            var model = new Domain.Models.Application
            {
                ApplicationReason = addApplicationViewModel.ApplicationReason,
                FullName = addApplicationViewModel.FullName,
                UserId = addApplicationViewModel.UserId,
                TariffId = addApplicationViewModel.TariffId
            };
           
            model.CreatedAt = DateTime.Now;
            model.StatusId = 1;
            return await _applicationRepository.Create(model);   
        }
        public async Task UpdateApplicationStatus(UpdateApplicationViewModel updateApplicationViewModel)
        {
            var model = await _applicationRepository.Get(x => x.ApplicationId == updateApplicationViewModel.Id);
            model.StatusId = updateApplicationViewModel.Status;
            await _applicationRepository.Update(model);
        }
    }
}
