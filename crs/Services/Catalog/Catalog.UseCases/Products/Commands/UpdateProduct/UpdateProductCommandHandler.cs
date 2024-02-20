namespace Catalog.UseCases.Products.Commands.UpdateProduct;

internal sealed class UpdateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) 
    : ICommandHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var productId = new ProductId(request.ProductId);
        var product = Product.Create(productId, request.ProductName);

        await _productRepository.UpdateProduct(product);
        await _unitOfWork.Commit(cancellationToken);
    }
}
