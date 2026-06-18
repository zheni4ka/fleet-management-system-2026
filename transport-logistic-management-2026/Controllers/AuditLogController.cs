using business_logic.Interfaces;
using business_logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace transport_logistic_management_2026.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditLogController : Controller
    {
        private readonly IAuditLogService _auditLogService;

        public AuditLogController(IAuditLogService auditLogService)
        {
            this._auditLogService = auditLogService;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_auditLogService.GetLogs());
        }
    }
}
