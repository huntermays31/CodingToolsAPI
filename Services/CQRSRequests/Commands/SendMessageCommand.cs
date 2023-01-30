using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Services.CQRSRequests.Commands
{
    public class SendMessageCommand : IRequest<string>
    {
        public string Message { get; set; }

        public SendMessageCommand(string message)
        {
            Message = message;
        }
    }
}
