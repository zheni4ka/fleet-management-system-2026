using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.DTOs
{
    public class AuditLogDTO
    {
        public int Id { get; set; }
        public string DispatcherId { get; set; }
        public DateTime Time { get; set; }
        public string Action { get; set; }
    }
}
