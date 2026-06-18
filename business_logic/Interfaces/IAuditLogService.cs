using business_logic.DTOs.AuditLog;
using business_logic.DTOs.AuditLogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.Interfaces
{
    public interface IAuditLogService
    {
        public void ClearLog();
        public void LogAction(string dispatcherId, string Action);
        public IEnumerable<AuditLogDTO> GetLogs();

    }
}
