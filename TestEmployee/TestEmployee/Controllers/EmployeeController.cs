using Autofac;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Business_Logic_Layer.Service;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web_API.DTOs;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;


        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

        }

        //https://stackoverflow.com/questions/54432916/asp-net-core-api-actionresultt-vs-async-taskt/54432964
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var employee = await _employeeService.GetAllEmployee();

                if (Equals(employee, null))
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (System.Exception exc)
            {
                throw new System.Exception(exc.Message);
            }
        }
    }
}