using CompanyControl.Domain.Entities;

namespace CompanyControl.Api.Dto.StaffDepartament
{
    public class PositionDto
    {
        public required string Name { get; set; }

        public Position Value { get; set; }
    }
}
