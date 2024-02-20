namespace Catalog.UseCases.Products.Queries.GetProductById;

internal sealed class GetProductByIdQueryHandler(
    IProductRepository productRepository) 
    : IQueryHandler<GetProductByIdQuery, Product?>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var productId = new ProductId(request.ProductId);
        return await _productRepository.GetProductByIdAsync(productId, cancellationToken);
    }
}
