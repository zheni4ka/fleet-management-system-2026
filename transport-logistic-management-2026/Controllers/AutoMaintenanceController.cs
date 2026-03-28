using business_logic.DTOs;
using business_logic.Interfaces;
using business_logic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace transport_logistic_management_2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoMaintenanceController : Controller
    {
        private readonly IAutoMaintenanceService _amservice;
        public AutoMaintenanceController(IAutoMaintenanceService amservice)
        {
            _amservice = amservice;
        }

        [HttpPost]
        public IActionResult Create([FromForm] CreateAutoMaintenanceModel model)
        {
            _amservice.Create(model);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _amservice.Get(id));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_amservice.GetAll());
        }

    }
}
