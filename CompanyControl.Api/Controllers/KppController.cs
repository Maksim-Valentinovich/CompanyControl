using AutoMapper;
using CompanyControl.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CompanyControl.Api.Controllers
{
    public class KppController : BaseApiController
    {
        public KppController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpPost("[action]")]
        public IActionResult StartShift(int employeeId, DateTime dateTime)
        {
            var employee = Context.Employees.FirstOrDefault(x => x.Id == employeeId);
            if (employee == null)
            {
                return BadRequest();
            }

            var existOldRunningShift = Context.Shifts.Any(s => s.EmployeeId == employeeId && s.End == null);
            if (existOldRunningShift) 
            {
                return BadRequest();
            }

            Context.Shifts.Add(new Domain.Entities.Shift
            {
                EmployeeId = employeeId,
                Start = dateTime,
                IsFail = dateTime.TimeOfDay > new TimeSpan(9, 0, 0)
            });
            Context.SaveChanges();

            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult EndShift(int employeeId, DateTime dateTime)
        {
            var shift = Context.Shifts.FirstOrDefault(x => x.EmployeeId == employeeId && x.End == null);
            if (shift == null)
            {
                return BadRequest();
            }

            var employee = Context.Employees.FirstOrDefault(x => x.Id == employeeId);
            if (employee == null)
            {
                return BadRequest();
            }

            var failTime = employee.Position == Domain.Entities.Position.Tester ? new TimeSpan(21, 0, 0) : new TimeSpan(18, 0, 0);
            shift.IsFail = dateTime.TimeOfDay < failTime;
            shift.End = dateTime;
            shift.WorkHours = (shift.End.Value - shift.Start).TotalHours;

            Context.Shifts.Update(shift);
            Context.SaveChanges();

            return Ok();
        }
    }
}
