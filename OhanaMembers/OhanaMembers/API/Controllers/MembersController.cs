using OhanaMembers.API.Commands;
using Microsoft.AspNetCore.Mvc;

namespace OhanaMembers.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly ILogger<MembersController> _logger;

        public MembersController(ILogger<MembersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
            => Ok(await new GetAll().Run());

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> Get([FromRoute] Get.Parameters par)
            => Ok(await new Get().Run(par));

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody] Insert.Parameters par)
            => Ok(await new Insert().Run(par));
    }
}