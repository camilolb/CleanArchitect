
namespace Pruebatecnica.Infrastructura.Data
{
    using Microsoft.EntityFrameworkCore;
    using Pruebatecnica.Infraestructura.Data.Configuration;
    using PruebaTecnica.Core.Entities;
    using System.Reflection;

    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Country> Country { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}