using Microsoft.EntityFrameworkCore;

namespace PricesComparation.Models.Context
{
    public class PricesComparationContext : DbContext
    {
        public PricesComparationContext(DbContextOptions<PricesComparationContext> options) : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Shop>()
            .HasOne(a => a.Address)
            .WithOne(s => s.Shop);

            modelBuilder.Entity<Address>()
            .HasOne(s => s.Shop)
            .WithOne(a => a.Address);

            modelBuilder.Entity<Product>()
                .HasOne(b => b.Brand)
                .WithMany(b => b.Products);
        }
    }
}
