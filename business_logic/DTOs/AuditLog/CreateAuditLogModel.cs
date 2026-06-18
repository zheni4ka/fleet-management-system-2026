using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.DTOs.AuditLogs
{
    public class CreateAuditLogModel
    {
        public string DispatcherId { get; set; }
        public DateTime Time { get; set; } = DateTime.UtcNow;
        public string Action { get; set; }
        public string Details { get; set; }
    }
}
