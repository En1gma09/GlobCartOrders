using GlobCartOrderService.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace GlobCartOrderService.Services.API.Models
{
    public class CreateUserViewModel
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public Role Role { get; set; }

    }
}
