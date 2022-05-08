using GlobCartOrderService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobCartOrderService.Domain.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetAll();

        User GetByEmail(String email, string password);

        ValidationResult<User> Create(User user);

        void Commit();
    }
}
