using GlobCartOrderService.Domain.Interfaces;
using GlobCartOrderService.Domain.Models;
using GlobCartOrderService.Infra.Data.Context;

namespace GlobCartOrderService.Services.API.Services
{
    public class ProductService : IProductService
    {
        private GlobCartOrderServiceContext globCartOrderServiceContext;

        public ProductService(GlobCartOrderServiceContext globCartOrderServiceContext)
        {
            this.globCartOrderServiceContext = globCartOrderServiceContext;
        }

        public ICollection<Product> GetProducts()
        {
            return globCartOrderServiceContext.Products.ToList();
        }

        public Product GetProductByName(string productName)
        {
            return globCartOrderServiceContext.Products.FirstOrDefault(p => p.ProductName.Equals(productName));
        }

        public ValidationResult<Product> CreateProduct(Product product)
        {
            var result = new ValidationResult<Product>(product);

            product.ProductId = Guid.NewGuid().ToString();
            product.ProductName = product.ProductName;
            product.UnitPrice = product.UnitPrice;
            product.ProductCreated = DateTime.Now;

            if (result.IsValid)
            {
                globCartOrderServiceContext.Products.Add(product);
                globCartOrderServiceContext.SaveChanges();
            }

            return result;

        }

        public Product UpdateProduct(string id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
