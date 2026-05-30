using business_logic.DTOs;
using business_logic.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace transport_logistic_management_2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoMaintenanceController : Controller
    {
        private readonly IAutoMaintenanceService _amservice;
        private readonly IValidator<CreateAutoMaintenanceModel> _createValidator;
        private readonly IValidator<EditAutoMaintenanceModel> _editValidator;
        public AutoMaintenanceController(IAutoMaintenanceService amservice, IValidator<CreateAutoMaintenanceModel> createValidator, IValidator<EditAutoMaintenanceModel> editValidator)
        {
            _amservice = amservice;
            _createValidator = createValidator;
            _editValidator = editValidator;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAutoMaintenanceModel model)
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

            _amservice.Create(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditAutoMaintenanceModel model)
        {
            var validationResult = _editValidator.Validate(model);
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

            await _amservice.Update(model);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _amservice.Delete(id);
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

        [HttpGet("auto/{id:int}")]
        public async Task<IActionResult> GetByAutoId([FromRoute] int id)
        {
            return Ok(await _amservice.GetByAutoId(id));
        }
    }
}
