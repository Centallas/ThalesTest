using AutoMapper;
using Business_Logic_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class AnnualSalary
    {
        public async Task<List<SaanDto>> GetEmplAnnualSalary(List<EmployeeDto> employees,IMapper _mapper)
        {
            await Task.Delay(1000);

            var emploSaal = new List<SaanDto>();
            var result = _mapper.Map<List<SaanDto>>(employees);

            emploSaal.AddRange(result.Select(
                employee => new SaanDto(employee.id)
                {
                    employee_name = employee.employee_name,
                    employee_age = employee.employee_age,
                    employee_salary = employee.employee_salary,
                    employee_annual_salary = employee.employee_salary * 12,
                    profile_image = employee.profile_image,
                }));

            return emploSaal;
        }

    }
}
