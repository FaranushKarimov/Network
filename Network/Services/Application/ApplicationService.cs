using AutoMapper;
using Network.DTO.Application;
using Network.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.DTO
{
    public class ApplicationService : IApplicationService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationRepository _applicationRepository;

        public ApplicationService(IMapper mapper, ApplicationRepository applicationRepository)
        {
            _mapper = mapper;
            _applicationRepository = applicationRepository;
        }
        public async Task<Domain.Models.Application> CreateAsync(AddApplicationViewModel addApplicationViewModel)
        {
            //var model = _mapper.Map<Domain.Models.Application>(addApplicationViewModel);
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var userName = User.FindFirstValue(ClaimTypes.Name);
            var model = new Domain.Models.Application
            {
                ApplicationReason = addApplicationViewModel.ApplicationReason,
                ManagerId = addApplicationViewModel.ManagerId
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
