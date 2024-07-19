using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyControl.Domain.Entities
{
    public class Shift : Entity
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public double WorkHours { get; set; }

        public bool IsFail { get; set; }

        public int EmployeeId { get; set; }

        public Employee? Employee { get; set; }
    }
}
