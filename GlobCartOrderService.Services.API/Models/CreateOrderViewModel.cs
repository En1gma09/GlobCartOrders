using System.ComponentModel.DataAnnotations;

namespace GlobCartOrderService.Services.API.Models
{
    public class CreateOrderViewModel
    {
        [Required]
        public string CustomerId { get; set; }

        [MinLength(1)]
        public List<CreateOrderProductViewModel> Products { get; set; }
    }
}
