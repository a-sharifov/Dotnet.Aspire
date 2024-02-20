namespace Catalog.UseCases.Products.Commands.DeleteProductById;

public sealed record DeleteProductByIdCommand(Guid ProductId) : ICommand;
