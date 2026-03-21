using Microsoft.AspNetCore.Mvc;
using business_logic.Interfaces;
using business_logic.DTOs;

namespace transport_logistic_management_2026.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : Controller
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpPost]
        public IActionResult Create([FromForm] CreateDriverModel model)
        {
            _driverService.Create(model);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _driverService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromForm] EditDriverModel model)
        {
            await _driverService.Edit(model);
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_driverService.GetAll());
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _driverService.Get(id));
        }
    }
}
