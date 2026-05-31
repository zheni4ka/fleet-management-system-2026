using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.DTOs
{
    public class ResponseAuth
    {   
        public string Token { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
