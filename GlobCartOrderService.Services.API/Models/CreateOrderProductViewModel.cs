using System.ComponentModel.DataAnnotations;

namespace GlobCartOrderService.Services.API.Models
{
    public class CreateOrderProductViewModel
    {
        [Required]
        public string ProductId { get; set; }
        
        [Range(1, 9999)]
        public int Quantity { get; set; }
    }
}
