//using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.DTOs.AuditLog
{
    public class AuditLogDTO
    {
        public int Id { get; set; }
        public string DispatcherId { get; set; }
        //public IdentityUser Dispatcher { get; set; }
        public DateTime Time { get; set; }
        public string Action { get; set; }
    }
}
