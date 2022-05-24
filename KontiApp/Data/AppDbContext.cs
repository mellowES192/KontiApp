using KontiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KontiApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Employee>? Employees { get; set; }

        public DbSet<EmployeesType>? EmployeesTypes { get; set; }

    }
}
