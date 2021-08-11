using Microsoft.EntityFrameworkCore;
using Network.DTO.PhoneNumber;
using Network.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Services.Operator
{
    public class OperatorService : IOperatorService
    {
        private readonly OperatorRepository _operatorRepository;
        public OperatorService(OperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }
        public async Task<List<GetOperatorViewModel>> GetOperatorAsync()
        {
            return await _operatorRepository.Entities.Select(x => new GetOperatorViewModel {
                OperatorId = x.Id,
                OperatorName = x.OperatorName
            }).ToListAsync();
        }
    }
}
