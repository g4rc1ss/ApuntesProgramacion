using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MediatrLibrary.Handlers.PublishMethod
{
    internal class PublishMethodTwoNotificationHandler : INotificationHandler<PublishMethodRequest>
    {
        private readonly IServiceProvider _serviceProvider;

        public PublishMethodTwoNotificationHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task Handle(PublishMethodRequest notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"El metodo PUBLISH 2 indica: {notification.Message}");

            return Task.CompletedTask;
        }
    }
}
