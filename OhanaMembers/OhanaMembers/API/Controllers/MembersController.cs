using OhanaMembers.API.Commands;
using Microsoft.AspNetCore.Mvc;
using OhanaMembers.API.Tools;

namespace OhanaMembers.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly ILogger<MembersController> _logger;
        private readonly HandlerFactory _hf;

        public MembersController(ILogger<MembersController> logger)
        {
            _logger = logger;
            _hf = new HandlerFactory();
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
            => Ok(await _hf.Run<GetAll.Handler>());

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> Get([FromRoute] Get.Parameters par)
            => Ok(await _hf.Run<Get.Handler>(par));

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody] Insert.Parameters par)
            => Ok(await _hf.Run<Insert.Handler>(par));

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update([FromBody] Update.Parameters par)
            => Ok(await _hf.Run<Update.Handler>(par));
    }
}