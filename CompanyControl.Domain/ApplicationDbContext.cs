using CompanyControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyControl.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } 

        public DbSet<Shift> Shifts { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
