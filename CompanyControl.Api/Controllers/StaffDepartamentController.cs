using AutoMapper;
using CompanyControl.Api.Dto.StaffDepartament;
using CompanyControl.Domain;
using CompanyControl.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace CompanyControl.Api.Controllers
{
    public class StaffDepartamentController : BaseApiController
    {
        public StaffDepartamentController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpPost("[action]")]
        public IActionResult AddEmployee(CreateEmployeeDto input)
        {
            var employee = Mapper.Map<Employee>(input);
            Context.Employees.Add(employee);
            Context.SaveChanges();

            return Ok(employee);
        }

        [HttpPut("[action]")]
        public IActionResult UpdateEmployee(UpdateEmployeeDto input)
        {
            var employee = Context.Employees.Find(input.Id);
            if (employee == null)
            {
                return BadRequest();
            }

            Mapper.Map(input, employee);
            Context.Employees.Update(employee);
            Context.SaveChanges();

            return Ok();
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteEmployee(int employeeId)
        {
            var employee = Context.Employees.Find(employeeId);
            if (employee == null) 
            {
                return BadRequest();
            }

            Context.Employees.Remove(employee);
            Context.SaveChanges();
            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult GetEmployees(Position? position)
        {
            IQueryable<Employee> query = Context.Employees.Include(e => e.Shifts);
            if (position.HasValue)
            {
                query = query.Where(e => e.Position == position);
            }

            var employees = query.ToList();
            var result = new List<EmployeeDto>();

            foreach (var employee in employees)
            {
                var dto = Mapper.Map<EmployeeDto>(employee);
                dto.Fails = employee.Shifts
                    .Where(s => s.IsFail)
                    .GroupBy(s => s.Start.ToString("MM.yyyy"))
                    .Select(g => new FailDto
                    {
                        Month = g.Key,
                        Count = g.Count(),
                    });

                result.Add(dto);
            }

            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetPositions() 
        {
            var positionValues = Enum.GetValues<Position>().ToList();
            var positions = Mapper.Map<IEnumerable<PositionDto>>(positionValues);
            return Ok(positions);
        }
    }
}
