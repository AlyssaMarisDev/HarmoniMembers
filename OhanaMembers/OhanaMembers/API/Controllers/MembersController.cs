using OhanaMembers.API.Commands.Members;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace OhanaMembers.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly ILogger<MembersController> _logger;
        private readonly IMediator _mediator;

        public MembersController(ILogger<MembersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
            => Ok(await _mediator.Send(new GetAll.Request()));

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> Get([FromRoute] Get.Request request)
            => Ok(await _mediator.Send(request));

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update([FromBody] Update.Request request)
            => Ok(await _mediator.Send(request));
    }
}