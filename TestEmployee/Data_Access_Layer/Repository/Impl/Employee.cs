using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class Employee : IEmployee
    {
       
        List<EmployeeEntity> listEmployee = new List<EmployeeEntity>();
        public async Task<List<EmployeeEntity>> GetAllEmployee()
        {
            var listEmployee = await GetEndPointData.EmployeeOpt();

            return listEmployee;
        }
    }
}
