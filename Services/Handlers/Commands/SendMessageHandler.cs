using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Services.CQRSRequests.Commands;

namespace Services.Handlers.Commands
{
    public class SendMessageHandler : IRequestHandler<SendMessageCommand, bool>
    {
        public async Task<bool> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            return false;
        }
    }
}
