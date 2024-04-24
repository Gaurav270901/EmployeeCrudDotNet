using AutoMapper;
using EmployeesAssignment.Models.Domain;
using EmployeesAssignment.Models.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeesAssignment.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee,AddEmployeeDto>().ReverseMap();
            CreateMap<Employee, DisplayEmployeeDto>().ReverseMap();
            CreateMap<Employee, EditEmployeeDto>().ReverseMap();

        }
    }
}
