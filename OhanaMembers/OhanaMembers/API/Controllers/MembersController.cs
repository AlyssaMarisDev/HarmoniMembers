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
        [Route("{Id}")]
        public async Task<IActionResult> Get([FromRoute] Get.Command command)
            => Ok(await new Get().Run(command));
    }
}