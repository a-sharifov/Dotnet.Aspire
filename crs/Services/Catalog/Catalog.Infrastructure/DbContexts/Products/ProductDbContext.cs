using Catalog.Core.ProductAggregate;

namespace Catalog.Infrastructure.DbContexts.Products;

public sealed class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => 
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
}
