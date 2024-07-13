using CompanyControl.Domain;
using CompanyControl.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CompanyControl.Api.Controllers
{
    public class StaffDepartamentController : BaseApiController
    {
        public StaffDepartamentController(ApplicationDbContext context) : base(context)
        {
        }

        public IActionResult AddEmployee(string name, string surname, Position? position)
        {
            if (name == null || surname == null || position == null)
            {
                return BadRequest();
            }

            Context.Employees.Add(new Employee
            {
                Id = Context.Employees.Last().Id + 1,
                Name = name,
                Surname = surname,

            });
            Context.SaveChanges();

            var newEmployee = Context.Employees.Last();
            string json = JsonSerializer.Serialize(newEmployee);
            return Ok(json);
        }

        public IActionResult UpdateEmployee(int? employeeId, string name, string surname, string middleName, Position position)
        {
            if (employeeId == null || !Context.Employees.Any(s => s.Id == employeeId))
            {
                return BadRequest();
            }

            Context.Employees.Where(x => x.Id == employeeId)
                .ExecuteUpdate(s => s
                    .SetProperty(p => p.Name, p => name)
                    .SetProperty(p => p.Surname, p => surname)
                    .SetProperty(p => p.MiddleName, p => middleName)
                    .SetProperty(p => p.Position, p => position));

            Context.SaveChanges();

            var employees = Context.Employees.Select(x => x);
            string json = JsonSerializer.Serialize(employees);
            return Ok(json);
        }

        public IActionResult DeleteEmployee(int? employeeId)
        {
            if (employeeId == null || !Context.Employees.Any(s => s.Id == employeeId))
            {
                return BadRequest();
            }
            Context.Employees.Select(s => s.Id == employeeId).ExecuteDelete();

            Context.SaveChanges();
            return Ok();
        }

        public IActionResult GetEmployees(Position? position)
        {
            string json = string.Empty;

            if (position != null)
            {
                if (Context.Employees.Any(x => x.Position == position))
                {
                    var employees = Context.Employees.Select(x => x);
                    json = JsonSerializer.Serialize(employees);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                var employees = Context.Employees.Select(x => x.Position == position);
                json = JsonSerializer.Serialize(employees);
            }

            return Ok(json);
        }
    }
}
