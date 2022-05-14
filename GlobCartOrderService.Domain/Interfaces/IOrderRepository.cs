using GlobCartOrderService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobCartOrderService.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Order GetByCode(string code);

        void Create(Order order);

        void Update(Order order);

        void Delete(Order order);

        void Commit();
    }
}
