namespace Catalog.UseCases.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(Guid ProductId, string ProductName) : ICommand;
