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
        public DbSet<Country> Countries { get; set; }
        public DbSet<Inflation> Inflations { get; set; }
        public DbSet<Depreciation> Depreciations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedVechileServiceType(modelBuilder);
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
        private static void SeedVechileServiceType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleServiceType>().HasData(new VehicleServiceType() { Id = new Guid("027b4ed4-649e-4ff9-8c85-4cdc4dfada5a"), Code = 22, DescriptionEng = "Auto", DescriptionAmh = "የቤት" , Point =6});
            modelBuilder.Entity<VehicleServiceType>().HasData(new VehicleServiceType() { Id = new Guid("027b4ed4-649e-4ff9-8c85-4cdc4dfada5b"), Code = 33, DescriptionEng = "Heavy", DescriptionAmh="ደረቅ" , Point =8});
            modelBuilder.Entity<VehicleServiceType>().HasData(new VehicleServiceType() { Id = new Guid("027b4ed4-649e-4ff9-8c85-4cdc4dfada5c"), Code = 44, DescriptionEng = "Public", DescriptionAmh = "ሀዝብ", Point=9 });
            modelBuilder.Entity<VehicleServiceType>().HasData(new VehicleServiceType() { Id = new Guid("027b4ed4-649e-4ff9-8c85-4cdc4dfada5d"), Code = 55, DescriptionEng = "Liq", DescriptionAmh = "ፈሳሽ" , Point =56});


        }
    }
}
