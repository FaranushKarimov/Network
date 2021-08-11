﻿using Network.DTO.PhoneNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Services.Operator
{
    public interface IOperatorService
    {
        Task<List<GetOperatorViewModel>> GetOperatorAsync();
    }
}
