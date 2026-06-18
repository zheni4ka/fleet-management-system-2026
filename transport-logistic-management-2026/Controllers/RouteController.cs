using Ardalis.Specification;
using business_logic.DTOs;
using business_logic.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace transport_logistic_management_2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RouteController : Controller
    {
        private readonly IRouteService _routeService;
        private readonly IValidator<CreateRouteModel> _createValidator;
        private readonly IValidator<EditRouteModel> _editValidator;
        private readonly UserManager<IdentityUser> _userManager;

        public RouteController(IRouteService routeService, IValidator<CreateRouteModel> createValidator, IValidator<EditRouteModel> editValidator, UserManager<IdentityUser> userManager)
        {
            this._routeService = routeService;
            this._createValidator = createValidator;
            this._editValidator = editValidator;
            this._userManager = userManager;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Dispatcher")]
        public IActionResult Create([FromBody] CreateRouteModel model)
        {
            var dispatcherId = User.FindFirstValue(ClaimTypes.NameIdentifier);

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

            _routeService.Create(model, dispatcherId);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin,Dispatcher")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var dispatcherId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _routeService.Delete(id, dispatcherId);
            return Ok();
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Dispatcher")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EditRouteModel model)
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

            await _routeService.Update(model);
            return Ok();
        }


        [HttpGet("all")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            return Ok(_routeService.GetAll());
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            return Ok(_routeService.Get(id));
        }
    }
}
