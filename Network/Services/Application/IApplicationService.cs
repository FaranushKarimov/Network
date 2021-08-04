using Network.DTO.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.DTO
{
    public interface IApplicationService
    {
        Task<Domain.Models.Application> CreateAsync(AddApplicationViewModel  addApplicationViewModel);
        Task UpdateApplicationStatus(UpdateApplicationViewModel updateApplicationViewModel);
    }
}
