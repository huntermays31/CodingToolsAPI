using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.CQRSRequests.Commands;

namespace CodingTools.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodingToolsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CodingToolsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CodingTools")]
        public async Task<ActionResult<string>> Get([FromBody] string message)
        {
            var result = await _mediator.Send(new SendMessageCommand(message));
            return Ok(result);
        }
    }
}