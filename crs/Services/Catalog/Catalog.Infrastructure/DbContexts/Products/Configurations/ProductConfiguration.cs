using Catalog.Core.ProductAggregate;
using Catalog.Core.ProductAggregate.Ids;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.DbContexts.Products.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            productId => productId.Value,
            productIdValue => new ProductId(productIdValue)
            );
    }
}
