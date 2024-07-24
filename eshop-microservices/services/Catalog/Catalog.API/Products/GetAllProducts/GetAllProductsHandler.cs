
namespace Catalog.API.Products.GetAllProducts
{
    public record GetAllProductsQuery () : IQuery<GetAllProductsResult>;
    public record GetAllProductsResult(IEnumerable<Product> Products);
    internal class GetAllProductsHandler(IDocumentSession session) : IQueryHandler<GetAllProductsQuery, GetAllProductsResult>
    {
        public async Task<GetAllProductsResult> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            // get products from db
            var allProducts = await session.Query<Product>().ToListAsync(cancellationToken);

            return new GetAllProductsResult(allProducts);
        }
    }
}
