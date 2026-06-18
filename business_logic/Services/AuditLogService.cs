using AutoMapper;
using business_logic.DTOs;
using business_logic.DTOs.AuditLog;
using business_logic.DTOs.AuditLogs;
using business_logic.Entities;
using business_logic.Interfaces;
using business_logic.Specifications;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace business_logic.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IRepository<AuditLog> _auditLogR;
        private readonly IMapper _mapper;
        public void LogAction(string dispatcherId, string Action)
        {
            CreateAuditLogModel log = new CreateAuditLogModel()
            {
                DispatcherId = dispatcherId,
                Action = Action,
                Time = DateTime.UtcNow
            };
            _auditLogR.Insert(_mapper.Map<AuditLog>(log));
            _auditLogR.Save();
        }

        public void ClearLog()
        {
        }

        public IEnumerable<AuditLogDTO> GetLogs()
        {
            var logs = _auditLogR.GetAll();
            return _mapper.Map<IEnumerable<AuditLogDTO>>(logs);
        }
    }
}
