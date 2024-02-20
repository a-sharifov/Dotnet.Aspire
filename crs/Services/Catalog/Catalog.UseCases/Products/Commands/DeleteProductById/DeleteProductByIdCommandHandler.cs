namespace Catalog.UseCases.Products.Commands.DeleteProductById;

internal sealed class DeleteProductByIdCommandHandler(
    IProductRepository productRepository, 
    IUnitOfWork unitOfWork): ICommandHandler<DeleteProductByIdCommand>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
    {
        var productId = new ProductId(request.ProductId);
        await _productRepository.DeleteProductByIdAsync(productId, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);
    }
}
