using System.Data.Entity;

namespace MVCCrudCodeFirst.Models
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext() : base("connectionStr")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; } 
        public DbSet<UserRole> Roles { get; set; } 
        public DbSet<PublisherModel> PublisherModels { get; set; }
    }
}