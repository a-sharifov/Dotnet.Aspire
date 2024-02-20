namespace Catalog.UseCases.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommand(Guid ProductId, string ProductName) : ICommand;
