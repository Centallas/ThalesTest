using Business_Logic_Layer.DTOs;
using Entity;
using AutoMapper;

namespace Business_Logic_Layer.Core
{
    public class MappingProfiles : AutoMapper.Profile
    {
        public MappingProfiles()
        {
            CreateMap<EmployeeEntity, EmployeeDto>()
                .ConstructUsing(user => new EmployeeDto(user.id))
                .ReverseMap()
                .ConstructUsing(userDto => new EmployeeEntity(userDto.id));

            CreateMap<EmployeeDto, SaanDto>().ForMember(x => x.employee_annual_salary,
                opt => opt.Ignore());
                //.ForMember(d => d.id, o => o.MapFrom(s => s.id));

        }

    }
}
