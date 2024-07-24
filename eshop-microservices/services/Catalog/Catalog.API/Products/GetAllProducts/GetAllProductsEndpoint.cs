
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetAllProducts
{
    public record GetAllProductsResponse(IEnumerable<Product> products);
    public class GetAllProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var response = await sender.Send(new GetAllProductsQuery());

                return Results.Ok(response.Adapt<GetAllProductsResponse>());

            }).WithName("GetAllProducts")
             .Produces<GetAllProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get all Products")
            .WithDescription("Get all Products");
        }
    }
}
