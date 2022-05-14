﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobCartOrderService.Domain.Models
{
    public class OrderProduct
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public String ProductId { get; set; }

        public String ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Total { get; set; }
    }
}
