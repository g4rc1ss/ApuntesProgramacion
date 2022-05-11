using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpRequests.Internal
{
    internal class MessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine(content);
            }

            return response;
        }
    }
}
