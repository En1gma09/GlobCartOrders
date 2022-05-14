using GlobCartOrderService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobCartOrderService.Domain.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();

        Product GetProductById(string productId);

        Product GetProductByName(string productName);

        ValidationResult<Product> CreateProduct(Product product);

        Product UpdateProduct(string id, Product product);

        Product DeleteProduct(string id, Product product);

        void Commit();
    }
}
