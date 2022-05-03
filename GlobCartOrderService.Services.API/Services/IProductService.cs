using GlobCartOrderService.Domain.Models;

namespace GlobCartOrderService.Services.API.Services
{
    public interface IProductService
    {
        ICollection<Product> GetProducts();

        Product GetProductByName(string productName);

        ValidationResult<Product> CreateProduct(Product product);

        Product UpdateProduct(string id, Product product);
    }
}
