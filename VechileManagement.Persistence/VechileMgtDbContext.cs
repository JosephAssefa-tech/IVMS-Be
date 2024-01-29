using VechileManagement.Domain.Common;
using VechileManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace VechileManagement.Persistence
{
    public class VechileMgtDbContext : DbContext
    {
        public VechileMgtDbContext(DbContextOptions<VechileMgtDbContext> options) : 
            base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<Factory> Factories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedFactory(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof
                (VechileMgtDbContext).Assembly);
            // possible to add here seeded data through migration
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken 
            = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        private static void SeedFactory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factory>().HasData(new Factory() { Id = new Guid("027b4ed4-649e-4ff9-8c85-4cdc4dfada5a"), FactoryName = "Hyundai" });
            modelBuilder.Entity<Factory>().HasData(new Factory() { Id = new Guid("027b4ed4-649e-4ff9-8c85-4cdc4dfada5b"), FactoryName = "Toyota" });
            modelBuilder.Entity<Factory>().HasData(new Factory() { Id = new Guid("027b4ed4-649e-4ff9-8c85-4cdc4dfada5c"), FactoryName = "Suzuki" });
            modelBuilder.Entity<Factory>().HasData(new Factory() { Id = new Guid("027b4ed4-649e-4ff9-8c85-4cdc4dfada5d"), FactoryName = "Ford" });


        }
    }
}
