using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace GlobCartOrderService.Services.API.Models
{
    public class ProductViewModel
    {
        [SwaggerSchema("Product Identifier")]
        [Key]
        public string? productId { get; set; }

        [SwaggerSchema("Product Name")]
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string productName { get; set; }

        [Range(10, 10000)]
        public decimal UnitPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime ProductCreated { get; set; }
    }
}
