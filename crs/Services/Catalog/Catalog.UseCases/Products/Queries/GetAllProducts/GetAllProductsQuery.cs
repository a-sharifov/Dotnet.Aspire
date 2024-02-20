namespace Catalog.UseCases.Products.Queries.GetAllProducts;

public sealed record GetAllProductsQuery() : IQuery<IList<Product>>;
