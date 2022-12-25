using Microsoft.EntityFrameworkCore;
using SorteioRetornar.Domain.Entities;
using SorteioRetornar.Infra.Data.Mapings;

namespace SorteioRetornar.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Client> Client { get; set; }
        public DbSet<GeneratedNumber> GeneratedNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new GeneratedNumberMap());
        }
    }
}
