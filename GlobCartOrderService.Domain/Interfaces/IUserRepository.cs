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
        User GetByEmail(String email, string password);

        void Create(User user);

        void Commit();
    }
}
