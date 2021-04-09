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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Shop>()
            .HasOne(a => a.Address)
            .WithOne();
            //commente
            modelBuilder.Entity<Shop>()
                .HasMany(p => p.Products)
                .WithOne(s => s.Shop);
            //comente
            modelBuilder.Entity<Brand>()
                .HasMany(p => p.Products)
                .WithOne(b => b.Brand);

        }
    }
}
