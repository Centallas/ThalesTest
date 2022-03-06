using Autofac;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.Service;
using Data_Access_Layer;
using Data_Access_Layer.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web_API.Controllers;
using Xunit;

namespace Web_API.Test
{
    public class EmpoyeeControllerTest
    {
        readonly EmployeeController _controller;
        readonly IEmployeeService _service;
        readonly IEmployee _employee;
        private readonly IMapper _mapper;
        public EmpoyeeControllerTest()
        {
            //Buld container mapper config using AutoMapper.Contrib.Autofac.DependencyInjection;             
            _mapper = SetIMapperType();
            _employee = new Employee();
            _service = new EmployeeService(_employee, _mapper);
            _controller = new EmployeeController(_service);
        }


        [Fact]
        public void GetAllTest()
        {
            //Act
            var result = _controller.GetAllEmployee();
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var list = result.Result as OkObjectResult;

            Assert.IsType<List<SaanDto>>(list.Value);

            var listEmployee = list.Value as List<SaanDto>;
            //There are currently 13 records in db. 02-15-2022
            Assert.Equal(24, listEmployee.Count);
        }

        [Fact]
        public void GetSaanDto()
        {

            var result = _service.GetAllEmployee();
            Assert.IsType<List<SaanDto>>(result.Result);
            Assert.Equal("3849600", (IEnumerable<char>)result.Result.FindLast(x => x.id == 1).employee_annual_salary.ToString());
         
        }

        [Fact]
        public void ValidateMappingConfig()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAutoMapper(typeof(EmployeeService).Assembly);

            var container = containerBuilder.Build();
            var mapperConfiguration = container.Resolve<MapperConfiguration>();

            // this line will throw when mappings are not working as expected
            // it's wise to write a test for that, which is always executed within a CI pipeline for your project.
            mapperConfiguration.AssertConfigurationIsValid();

        }

        private static IMapper SetIMapperType()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAutoMapper(typeof(EmployeeService).Assembly, propertiesAutowired: true);
            var container = containerBuilder.Build();

            return container.Resolve<IMapper>();

        }
    }
}
