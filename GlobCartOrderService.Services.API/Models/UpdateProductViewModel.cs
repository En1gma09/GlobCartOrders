namespace GlobCartOrderService.Services.API.Models
{
    public class UpdateProductViewModel
    {
        public string? productId { get; set; }

        public string productName { get; set; }

        public decimal UnitPrice { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
