namespace Catalog.Presentation.Endpoints.Products;

public static class ProductsEndpoints 
{
    public static void MapProductsEndpoints(this IEndpointRouteBuilder builder)
    {
        var productBuilder = builder.MapGroup("/products");

        productBuilder.MapGet("/", () => { }).WithName("GetAllProducts");
        productBuilder.MapGet("/{userId:guid}", (Guid userId) => { }).WithName("GetProducts");
        productBuilder.MapPost("/{userId:guid}", (Guid userId) => { }).WithName("GetProducts");
        productBuilder.MapPut("/", () => { }).WithName("UpdateProduct");
        productBuilder.MapDelete("/", () => { }).WithName("DeleteProductById");
    }


}
