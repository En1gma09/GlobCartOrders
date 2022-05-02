using GlobCartOrderService.Domain.Models;

namespace GlobCartOrderService.Services.API.Services
{
    public interface IUserService
    {
        User GetUser(string email, string password);
        ValidationResult<User> CreateUser(User user);
    }
}
