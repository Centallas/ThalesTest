using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Business_Logic_Layer.DTOs;
using Data_Access_Layer;
using Data_Access_Layer.Repository;
using Entity;

namespace Business_Logic_Layer.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployee _employee;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployee employee, IMapper mapper)
        {
            _employee = employee;
            _mapper = mapper;
        }
        public async Task<List<EmployeeDto>> GetAllEmployee()
        {
            var resService = await _employee.GetAllEmployee();
            return MapListEmployeeEntity(resService);

        }
        private EmployeeDto MapEmployeeEntity(EmployeeEntity employee)
        {
            return _mapper.Map<EmployeeDto>(employee);
        }

        private List<EmployeeDto> MapListEmployeeEntity(List<EmployeeEntity> resService)
        {
            return _mapper.Map<List<EmployeeDto>>(resService);
        }

    }
}