using Catalog.Core.ProductAggregate.Ids;

namespace Catalog.Core.ProductAggregate.Repositories;

public interface IProductRepository
{
    Task<Product?> GetProductByIdAsync(ProductId productId, CancellationToken cancellationToken = default);
    Task AddProductAsync(Product product, CancellationToken cancellationToken = default);
    Task UpdateProduct(Product product);
    Task DeleteProductByIdAsync(ProductId productId, CancellationToken cancellationToken = default);
    Task<IList<Product>> GetAllProductsAsync(CancellationToken cancellationToken = default);
}
