using Catalog.Presentation.Endpoints.Products.Models;
using Catalog.UseCases.Products.Commands.CreateProduct;
using Catalog.UseCases.Products.Commands.DeleteProductById;
using Catalog.UseCases.Products.Commands.UpdateProduct;
using Catalog.UseCases.Products.Queries.GetAllProducts;
using Catalog.UseCases.Products.Queries.GetProductById;

namespace Catalog.Presentation.Endpoints.Products;

public static class ProductsEndpoints 
{
    public static void MapProductsEndpoints(this IEndpointRouteBuilder builder)
    {
        var productBuilder = builder.MapGroup("/products");

        productBuilder.MapGet("/", GetAllProducts).WithName("GetAllProducts");
        productBuilder.MapGet("/{productId:guid}", GetProduct).WithName("GetProduct");
        productBuilder.MapPost("/", CreateProduct).WithName("CreateProduct");
        productBuilder.MapPut("/", UpdateProduct).WithName("UpdateProduct");
        productBuilder.MapDelete("/{productId:guid}", DeleteProductById).WithName("DeleteProductById");
    }


    private static async Task<IResult> GetAllProducts(ISender sender)
    {
        var command = new GetAllProductsQuery();
        var products = await sender.Send(command);
        return Results.Ok(products);
    }

    private static async Task<IResult> GetProduct(Guid productId, ISender sender)
    {
        var command = new GetProductByIdQuery(productId);
        var product = await sender.Send(command);
        return Results.Ok(product);
    }

    private static async Task<IResult> CreateProduct(CreateProductRequest request, ISender sender)
    {
        var command = new CreateProductCommand(request.ProductName);
        await sender.Send(command);
        return Results.Ok();
    }

    private static async Task<IResult> UpdateProduct(UpdateProductRequest request, ISender sender)
    {
        var command = new UpdateProductCommand(request.ProductId, request.ProductName);
        await sender.Send(command);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteProductById(Guid productId, ISender sender)
    {
        var command = new DeleteProductByIdCommand(productId);
        await sender.Send(command);
        return Results.Ok();
    }

}
