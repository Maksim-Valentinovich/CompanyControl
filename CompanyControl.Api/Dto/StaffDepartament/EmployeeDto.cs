using CompanyControl.Api.Dto.Common;
using CompanyControl.Domain.Entities;

namespace CompanyControl.Api.Dto.StaffDepartament
{
    public class EmployeeDto : EntityDto
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public Position Position { get; set; }

        public IEnumerable<FailDto> Fails { get; set; }
    }
}
