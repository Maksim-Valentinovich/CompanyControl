using AutoMapper;
using CompanyControl.Api.Dto.StaffDepartament;
using CompanyControl.Domain.Entities;

namespace CompanyControl.Api.Mapping
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile() 
        {
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
        }
    }
}
