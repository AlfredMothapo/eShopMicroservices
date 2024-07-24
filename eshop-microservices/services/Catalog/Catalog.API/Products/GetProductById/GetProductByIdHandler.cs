
namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid id): IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
    internal class GetProductByIdQueryHandler(IQuerySession session) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.id, cancellationToken);

            if (product != null) { 
                return new GetProductByIdResult(product);
            }
            throw new ProductNotFoundException();
        }
    }
}
