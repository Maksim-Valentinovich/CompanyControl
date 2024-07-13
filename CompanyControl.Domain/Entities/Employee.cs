using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyControl.Domain.Entities
{
    public class Employee : Entity
    {
        public required string Surname { get; set; }
        public required string Name { get; set; }
        public string? MiddleName { get; set; }

        [NotMapped]
        public string FullName => $"{Surname} {Name} {MiddleName}";

        public Position Position { get; set; }

        public virtual ICollection<Shift>? Shifts { get; set; }
    }
}
