using GlobCartOrderService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobCartOrderService.Domain.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<User> RegisterAsync(User user, string password);
        Task<User> LoginAsync(string email, string password);
        Task<bool> UserExistsAsync(string email);
    }
}
