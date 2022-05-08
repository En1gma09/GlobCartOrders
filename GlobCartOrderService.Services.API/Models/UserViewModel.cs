using GlobCartOrderService.Domain.Models;

namespace GlobCartOrderService.Services.API.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public UserViewModel(string name, string email, string password, Role role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}