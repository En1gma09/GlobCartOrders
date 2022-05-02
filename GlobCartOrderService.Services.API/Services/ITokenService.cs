using GlobCartOrderService.Domain.Models;

namespace GlobCartOrderService.Services.API.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
