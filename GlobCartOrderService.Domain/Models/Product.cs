using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobCartOrderService.Domain.Models
{
    public class Product
    {
        public string? productId { get; set; }

        public string productName { get; set; }

        public decimal UnitPrice { get; set; }

        public DateTime ProductCreated { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
