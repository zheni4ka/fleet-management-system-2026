using business_logic.DTOs;
using business_logic.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace transport_logistic_management_2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly ILocationService _service;
        private readonly IValidator<CreateLocationModel> _validator;

        public LocationController(ILocationService service, IValidator<CreateLocationModel> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateLocationModel model)
        {
            var v = _validator.Validate(model);
            if (!v.IsValid) return BadRequest(v.ToDictionary());
            _service.Create(model);
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id:int}")]
        public IActionResult Get(int id) => Ok(_service.Get(id));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
