﻿using System.ComponentModel.DataAnnotations;

namespace GlobCartOrderService.Services.API.Models
{
    public class UserLoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
