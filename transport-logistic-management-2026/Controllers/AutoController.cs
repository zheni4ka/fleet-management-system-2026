using business_logic.DTOs;
using business_logic.Entities;
using business_logic.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace transport_logistic_management_2026.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoController : Controller
    {
        private readonly IAutoService _autoService;
        private readonly IValidator<CreateAutoModel> _createValidator;
        private readonly IValidator<EditAutoModel> _editValidator;

        public AutoController(IAutoService autoService, IValidator<CreateAutoModel> createValidator, IValidator<EditAutoModel> editValidator)
        {
            _autoService = autoService;
            _createValidator = createValidator;
            _editValidator = editValidator;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAutoModel auto)
        {
            var validationResult = _createValidator.Validate(auto);
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

            _autoService.Create(auto);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _autoService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditAutoModel model)
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

            await _autoService.Edit(model);
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_autoService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_autoService.Get(id));
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] AutoStatus newStatus)
        {
            try
            {
                await _autoService.UpdateStatus(id, newStatus);
                return Ok(new { message = "Status updated successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

    }
}
