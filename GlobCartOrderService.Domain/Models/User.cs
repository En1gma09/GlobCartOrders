using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobCartOrderService.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        //public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; }

        //public User(Guid id, string name, string email, string password)
        //{
        //    Id = Guid.NewGuid();
        //    Name = name;
        //    Email = email;
        //    Password = password;
        //}
    }
}
