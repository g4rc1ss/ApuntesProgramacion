using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MediatrLibrary.Handlers.SendMethod
{
    internal class SendMethodRequest : IRequest<SendMethodResponse>
    {
        public string Message { get; set; }
    }
}
