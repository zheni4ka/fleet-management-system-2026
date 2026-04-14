using Microsoft.AspNetCore.Mvc;
using business_logic.Interfaces;
using business_logic.DTOs;
using FluentValidation;

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
        public IActionResult Create([FromForm] CreateAutoModel auto)
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
        public async Task<IActionResult> Edit([FromForm] EditAutoModel model)
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
    }
}
