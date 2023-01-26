using Microsoft.AspNetCore.Mvc;

namespace CodingTools.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodingToolsController : ControllerBase
    {

        [HttpGet(Name = "CodingTools")]
        public async Task<ActionResult<string>> Get()
        {
            return Ok(true);
        }
    }
}