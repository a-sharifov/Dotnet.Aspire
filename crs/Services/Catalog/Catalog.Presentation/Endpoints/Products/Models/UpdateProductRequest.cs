namespace Catalog.Presentation.Endpoints.Products.Models;

public sealed record UpdateProductRequest(
    Guid ProductId,
    string ProductName
    );
