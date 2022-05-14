using GlobCartOrderService.Domain.Models;

namespace GlobCartOrderService.Services.API.Services
{
    public interface IOrderService
    {
        ValidationResult<Order> CreateOrder(Order order);

        void CancelOrder(String code);

        Order FindOrder(String code);
    }
}
