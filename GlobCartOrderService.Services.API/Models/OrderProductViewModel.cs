namespace GlobCartOrderService.Services.API.Models
{
    public class OrderProductViewModel
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Total { get; set; }
    }
}
