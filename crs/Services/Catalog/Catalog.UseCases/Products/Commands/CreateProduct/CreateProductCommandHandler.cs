namespace Catalog.UseCases.Products.Commands.CreateProduct;

internal sealed class CreateProductCommandHandler(
    IProductRepository productRepository, 
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productId = new ProductId(request.ProductId);
        var productName = request.ProductName;
        var product = Product.Create(productId, productName);

        await _productRepository.AddProductAsync(product, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);
    }
}
