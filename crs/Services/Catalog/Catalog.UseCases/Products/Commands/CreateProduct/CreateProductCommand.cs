namespace Catalog.UseCases.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(string ProductName) : ICommand;
