using GlobCartOrderService.Domain.Models;

namespace GlobCartOrderService.Services.API.Services
{
    public interface IUserService
    {
        ICollection<User> GetUsers();
        User GetUser(string email, string password);
        ValidationResult<User> CreateUser(User user);
    }
}
