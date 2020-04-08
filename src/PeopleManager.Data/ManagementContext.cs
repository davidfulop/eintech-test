using Microsoft.EntityFrameworkCore;

namespace PeopleManager.Data
{
    public class ManagementContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Person> Persons { get; set; }

        public ManagementContext() { }

        public ManagementContext(DbContextOptions<ManagementContext> options)
            : base(options)
        { }
    }
}
