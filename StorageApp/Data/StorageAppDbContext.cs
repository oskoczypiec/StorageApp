using Microsoft.EntityFrameworkCore;
using StorageApp.Entities;

namespace StorageApp.Data
{
    public class StorageAppDbContext : DbContext
    {
        public DbSet<Employee> Employess => Set<Employee>();
        public DbSet<Organization> Organizations => Set<Organization>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }

    }
}
