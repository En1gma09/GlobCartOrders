using GlobCartOrderService.Domain.Interfaces;
using GlobCartOrderService.Domain.Models;
using GlobCartOrderService.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobCartOrderService.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly GlobCartOrderServiceContext _globCartOrderServiceContext;

        public ProductRepository(GlobCartOrderServiceContext globCartOrderServiceContext)
        {
            _globCartOrderServiceContext = globCartOrderServiceContext;
        }

        public ICollection<Product> GetProducts()
        {
            return _globCartOrderServiceContext.Products.ToList();
        }

        public Product GetProductById(string productId)
        {
            return _globCartOrderServiceContext.Products.FirstOrDefault(product => product.ProductId == productId);
        }

        public Product GetProductByName(string productName)
        {
            return _globCartOrderServiceContext.Products.FirstOrDefault(product => product.ProductName == productName);
        }

        public ValidationResult<Product> CreateProduct(Product product)
        {
            var result = new ValidationResult<Product>(product);

            product.ProductId = Guid.NewGuid().ToString();

            if (result.IsValid)
            {
                _globCartOrderServiceContext.Products.Add(product);
                _globCartOrderServiceContext.SaveChanges();
            }

            return result;
        }

        public Product UpdateProduct(string id, Product product)
        {

            if (id != null)
            {
                _globCartOrderServiceContext.Update(product);
                _globCartOrderServiceContext.SaveChanges();
            }

            return product;
        }

        public Product DeleteProduct(string id, Product product)
        {
            if (id != null)
            {
                _globCartOrderServiceContext.Remove(product);
                _globCartOrderServiceContext.SaveChanges();
            }

            return product;
        }

        public void Commit()
        {
            _globCartOrderServiceContext.SaveChanges();
        }
    }
}
