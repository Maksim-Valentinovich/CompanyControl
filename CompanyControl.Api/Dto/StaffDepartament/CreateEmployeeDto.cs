using CompanyControl.Domain.Entities;

namespace CompanyControl.Api.Dto.StaffDepartament
{
    public class CreateEmployeeDto
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string? MiddleName { get; set; }
        public required Position Position { get; set; }
    }
}
