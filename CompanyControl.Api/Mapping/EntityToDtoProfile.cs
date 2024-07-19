using AutoMapper;
using CompanyControl.Api.Dto.StaffDepartament;
using CompanyControl.Domain.Entities;
using EnumsNET;

namespace CompanyControl.Api.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile() 
        {
            CreateMap<Position, PositionDto>()
                .ForMember(x => x.Value, y => y.MapFrom(r => r))
                .ForMember(x => x.Name, y => y.MapFrom(r => r.AsString(EnumFormat.Description)));

            CreateMap<Employee, EmployeeDto>();
        }
    }
}
