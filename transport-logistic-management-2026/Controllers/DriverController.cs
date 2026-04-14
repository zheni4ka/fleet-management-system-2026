using Microsoft.AspNetCore.Mvc;
using business_logic.Interfaces;
using business_logic.DTOs;
using FluentValidation;

namespace transport_logistic_management_2026.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : Controller
    {
        private readonly IDriverService _driverService;
        private readonly IValidator<CreateDriverModel> _createValidator;
        private readonly IValidator<EditDriverModel> _editValidator;

        public DriverController(IDriverService driverService, IValidator<CreateDriverModel> createValidator, IValidator<EditDriverModel> editValidator)
        {
            _driverService = driverService;
            _createValidator = createValidator;
            _editValidator = editValidator;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateDriverModel model)
        {
            var validationResult = _createValidator.Validate(model);
            if (!validationResult.IsValid)
            {
                var errors = new ValidationProblemDetails(validationResult.ToDictionary())
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Validation Failed",
                    Detail = "One or more validation errors occurred."
                };

                return BadRequest(errors);
            }

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
        public async Task<IActionResult> Edit([FromBody] EditDriverModel model)
        {
            var validationResult = _editValidator.Validate(model);
            if (!validationResult.IsValid)
            {
                var errors = new ValidationProblemDetails(validationResult.ToDictionary())
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Validation Failed",
                    Detail = "One or more validation errors occurred.",
                    Instance = "/api/drivers"
                };

                return BadRequest(errors);
            }

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
