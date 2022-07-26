using Day3.Shared;
using Microsoft.EntityFrameworkCore;

namespace Day3.WebAPI.Models
{
    public class ITIEntity:DbContext
    {
        public ITIEntity()
        {

        }
        public ITIEntity(DbContextOptions options):base(options)
        {

        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
