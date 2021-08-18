using Network.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Services.User
{
    public interface IUserService
    {
        Task<List<UsersViewModel>> GetAllUsers();
    }
}
