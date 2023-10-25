using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobCartOrderService.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public string CustomerId { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime? CancelledDate { get; set; }

        public OrderStatus Status { get; set; }

        public List<OrderProduct> Products { get; set; } = new List<OrderProduct>();

        public decimal Total { get; set; }
    }
}
