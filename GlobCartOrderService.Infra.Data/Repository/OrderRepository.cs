using GlobCartOrderService.Domain.Interfaces;
using GlobCartOrderService.Domain.Models;
using GlobCartOrderService.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobCartOrderService.Infra.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GlobCartOrderServiceContext _globCartOrderServiceContext;

        public OrderRepository(GlobCartOrderServiceContext globCartOrderServiceContext)
        {
            _globCartOrderServiceContext = globCartOrderServiceContext;
        }

        public Order GetByCode(string code)
        {
            return _globCartOrderServiceContext
                .Orders
                .Include(order => order.Products)
                .FirstOrDefault(order => order.Code.Equals(code));
        }

        public void Create(Order order)
        {
            _globCartOrderServiceContext.Orders.Add(order);
        }

        public void Update(Order order)
        {
            _globCartOrderServiceContext.Update(order);
        }

        public void Delete(Order order)
        {
            _globCartOrderServiceContext.Orders.Remove(order);
        }

        public void Commit()
        {
            _globCartOrderServiceContext.SaveChanges();
        }
    }
}
