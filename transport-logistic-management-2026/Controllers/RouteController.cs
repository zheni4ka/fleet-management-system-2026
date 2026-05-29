using Ardalis.Specification;
using business_logic.DTOs;
using business_logic.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace transport_logistic_management_2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RouteController : Controller
    {
        private readonly IRouteService _routeService;
        private readonly IValidator<CreateRouteModel> _createValidator;
        private readonly UserManager<IdentityUser> _userManager;

        public RouteController(IRouteService routeService, IValidator<CreateRouteModel> createValidator, UserManager<IdentityUser> userManager)
        {
            this._routeService = routeService;
            this._createValidator = createValidator;
            this._userManager = userManager;
        }

        [HttpPost]
        //[Authorize(Roles = "Dispatcher")]
        public IActionResult Create([FromBody] CreateRouteModel model)
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

            _routeService.Create(model);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        //[Authorize(Roles = "Dispatcher")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _routeService.Delete(id);
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
