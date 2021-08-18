using Microsoft.EntityFrameworkCore;
using Network.DTO.Users;
using Network.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Services.User
{
    public class UserService : IUserService
    {
        private readonly DepartmentRepository _departmentRepository;
        private readonly UserRepository _userRepository;

        public UserService(DepartmentRepository departmentRepository,UserRepository userRepository)
        {
            _departmentRepository = departmentRepository;
            _userRepository = userRepository;
        }

        public async Task<List<UsersViewModel>> GetAllUsers()
        {
            return await _userRepository.Entities.Include(x => x.Department).Select(x => new UsersViewModel { Username = x.UserName, DepartmentName = x.Department.DepartmentName, Email = x.Email }).ToListAsync();
        }
    }
}
