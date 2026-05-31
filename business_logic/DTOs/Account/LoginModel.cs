using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace business_logic.DTOs
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username or Email is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
