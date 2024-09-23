using OhanaMembers.API.Commands.Auth;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace OhanaMembers.API.Controllers
{
    [ApiController]
    [Route("")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<MembersController> _logger;
        private readonly IMediator _mediator;

        public AuthController(ILogger<MembersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignIn.Request request)
            => Ok(await _mediator.Send(request));

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Register.Request request)
            => Ok(await _mediator.Send(request));
    }
}