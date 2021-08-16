using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Network.DTO.Account;
using Network.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.DTO
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(DepartmentRepository departmentRepository,IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;  
        }

        public async Task<Department> Create(DepartmentViewModel department)
        {
            var model = _mapper.Map<Domain.Models.Department>(department);
        //    model.CreatedAt = DateTime.Now;
            return await _departmentRepository.Create(model);
        }

        public async Task Delete(int id) {
            var department = await _departmentRepository.Get(id);
            await _departmentRepository.Delete(department);
        }

        public async Task EditDepartment(DepartmentViewModel model)
        {
            var department = await _departmentRepository.Get(x => x.DepartmentId == model.DepartmentId);
            var editDepartment = _mapper.Map<Domain.Models.Department>(model);
            await _departmentRepository.Update(editDepartment);
        }

        public async Task <List<DepartmentViewModel>> GetAll()
        {
            var departments = await _departmentRepository.GetAll();
            return departments.Select(x => new DepartmentViewModel
            {
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName
            }).ToList();
        }

        public async Task<DepartmentViewModel> GetById (int id)
        {
            if (id == 0)
            {
                throw new Exception("Department with this id not found");
            }
            var department = await _departmentRepository.Get(id);
            var departmentDTO = _mapper.Map<DepartmentViewModel>(department);
            return departmentDTO; 
        }
        
        public async Task<List<SelectListItem>> GetDepartmentList()
        {
            var result = await _departmentRepository.GetDepartmentList();
            return result;
        }
    }
}
