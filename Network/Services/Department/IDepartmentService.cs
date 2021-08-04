using Domain.Models;
using Network.DTO.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Network.DTO
{
    public interface IDepartmentService
    {
        Task<Department> Create(DepartmentViewModel model);
        Task EditDepartment(DepartmentViewModel model);
        Task<List<DepartmentViewModel>> GetAll();
        Task<DepartmentViewModel> GetById(int id);
        Task Delete (int id);

    }
}
