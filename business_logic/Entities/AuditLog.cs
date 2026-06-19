using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.Entities
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string DispatcherId { get; set; }
        public IdentityUser Dispatcher { get; set; }
        public DateTime Time { get; set; } = DateTime.UtcNow;
        public string Action { get; set; }
    }
}
