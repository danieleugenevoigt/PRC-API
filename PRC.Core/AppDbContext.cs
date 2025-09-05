using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PRC.Core.Entities;

namespace PRC.Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
        public DbSet<Products> Products => Set<Products>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<ProductImage> ProductImages => Set<ProductImage>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship (Products <-> Categories)
            modelBuilder.Entity<Products>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "product_categories",
                    j => j.HasOne<Category>().WithMany().HasForeignKey("category_id"),
                    j => j.HasOne<Products>().WithMany().HasForeignKey("product_id")
                );
            
            // Configure one-to-many relationship (Products -> ProductImages)
            modelBuilder.Entity<Products>()
                .HasMany(p => p.ProductImages)
                .WithOne(pi => pi.Product)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
                
            base.OnModelCreating(modelBuilder);
        }
    }
}
