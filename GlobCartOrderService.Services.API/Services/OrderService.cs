using GlobCartOrderService.Domain.Interfaces;
using GlobCartOrderService.Domain.Models;

namespace GlobCartOrderService.Services.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        public Order FindOrder(string code)
        {
            return orderRepository.GetByCode(code);
        }

        public ValidationResult<Order> CreateOrder(Order order)
        {
            var result = new ValidationResult<Order>(order);

            ValidateCustomer(result);
            ValidateProducts(result);

            order.Id = Guid.NewGuid();
            order.Code = string.Format("{0:yyyymmdd}_{1}", DateTime.Now, order.CustomerId);

            order.CreatedDate = DateTime.Now;
            order.UpdatedDate = DateTime.Now;

            order.Status = OrderStatus.Pending;

            order.Total = 0;

            foreach (var orderProduct in order.Products)
            {
                var product = productRepository.GetProductById(orderProduct.ProductId);

                if (product == null)
                    result.Errors.Add($"Product {orderProduct.ProductId} not found.");
                else
                {
                    orderProduct.Id = Guid.NewGuid();
                    orderProduct.ProductName = product.ProductName;
                    orderProduct.UnitPrice = product.UnitPrice;
                    orderProduct.Total = orderProduct.Quantity * orderProduct.UnitPrice;

                    order.Total += orderProduct.Total;
                }
            }

            if (result.IsValid)
            {
                orderRepository.Create(order);
                orderRepository.Commit();
            }

            return result;
        }

        public void CancelOrder(string code)
        {
            var order = orderRepository.GetByCode(code);
            if (order == null)
                throw new Exception("Order not found");

            if (order.Status == OrderStatus.Canceled)
                throw new Exception("Order is already canceled");

            order.Status = OrderStatus.Canceled;
            order.CancelledDate = DateTime.Now;

            orderRepository.Update(order);
            orderRepository.Commit();
        }

        private void ValidateCustomer(ValidationResult<Order> result)
        {
            if (string.IsNullOrEmpty(result.Model.CustomerId))
                result.Errors.Add("Missing CustomerId");
        }

        private void ValidateProducts(ValidationResult<Order> result)
        {
            if (!result.Model.Products.Any())
                result.Errors.Add("Missing Products");
        }
    }
}
