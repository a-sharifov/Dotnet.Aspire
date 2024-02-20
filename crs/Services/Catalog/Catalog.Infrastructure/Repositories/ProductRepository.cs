using Catalog.Core.ProductAggregate;
using Catalog.Core.ProductAggregate.Ids;
using Catalog.Core.ProductAggregate.Repositories;
using Catalog.Infrastructure.Caching;
using Catalog.Infrastructure.DbContexts.Products;

namespace Catalog.Infrastructure.Repositories;

public sealed class ProductRepository(
    ProductDbContext productDbContext,
    CachedEntityService<Product, ProductId> cachedService) : IProductRepository
{
    private readonly ProductDbContext _productDbContext = productDbContext;
    private readonly CachedEntityService<Product, ProductId> _cachedService = cachedService;

    public async Task AddProductAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _productDbContext.AddAsync(product, cancellationToken);
        await _cachedService.SetAsync(product, cancellationToken: cancellationToken);
    }

    public async Task DeleteProductByIdAsync(ProductId productId, CancellationToken cancellationToken = default)
    {
        var product = await _productDbContext.Set<Product>().FindAsync([productId], cancellationToken);

        if (product is null)
        {
            return;
        }

        await _cachedService.DeleteAsync(productId, cancellationToken);
        _productDbContext.Set<Product>().Remove(product);
    }

    public async Task<IList<Product>> GetAllProductsAsync(CancellationToken cancellationToken = default) =>
        await _productDbContext.Set<Product>().ToListAsync(cancellationToken: cancellationToken);

    public async Task<Product?> GetProductByIdAsync(ProductId productId, CancellationToken cancellationToken)
    {
        var product = await _cachedService.GetAsync(productId, cancellationToken);

        return product ?? await _productDbContext.Set<Product>().FindAsync([productId], cancellationToken);
    }

    public void UpdateProduct(Product product) => _productDbContext.Update(product);

}
