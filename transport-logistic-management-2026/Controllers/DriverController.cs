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
        public IActionResult CreateDriver([FromForm] CreateDriverModel model)
        {
            _driverService.Create(model);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteDriver([FromRoute] int id)
        {
            return Ok(_driverService.Delete(id));
        }


        [HttpGet("all")]
        public IActionResult GetAllDrivers()
        {
            return Ok(_driverService.GetAll());
        }


        [HttpGet("{id:int}")]
        public IActionResult GetDriverById([FromRoute] int id)
        {
            return Ok(_driverService.Get(id));
        }
    }
}
