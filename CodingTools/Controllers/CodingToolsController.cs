using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
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
        public async Task<ActionResult<string>> Get([FromBody] SendMessageDto message)
        {
            var result = await _mediator.Send(new SendMessageCommand(message.Message));
            return Ok(result);
        }
    }
}