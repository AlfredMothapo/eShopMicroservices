namespace Catalog.API.Exceptions
{
    public class ProductNotFoundException: Exception
    {
        public ProductNotFoundException(): base("Error, requested product was not found!") { }

    }
}
