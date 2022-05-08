using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace GlobCartOrderService.Services.API.Models
{
    public class DeleteProductViewModel
    {
        [SwaggerSchema("Product Identifier")]
        [Key]
        public string? productId { get; set; }
    }
}
