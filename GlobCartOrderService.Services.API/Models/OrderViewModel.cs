﻿namespace GlobCartOrderService.Services.API.Models
{
    public class OrderViewModel
    {
        public string CustomerId { get; set; }

        public string Code { get; set; }

        public string Status { get; set; }

        public List<OrderProductViewModel> Products { get; set; }

        public decimal Total { get; set; }
    }
}
