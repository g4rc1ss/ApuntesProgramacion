using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MediatrLibrary.Handlers.PublishMethod
{
    internal class PublishMethodRequest : INotification
    {
        public string Message { get; set; }
    }
}
