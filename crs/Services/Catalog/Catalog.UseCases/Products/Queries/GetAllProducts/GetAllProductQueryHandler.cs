namespace Catalog.UseCases.Products.Queries.GetAllProducts;

internal sealed class GetAllProductQueryHandler(
    IProductRepository productRepository) 
    : IQueryHandler<GetAllProductsQuery, IList<Product>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<IList<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken) =>
        await _productRepository.GetAllProductsAsync(cancellationToken);
}
