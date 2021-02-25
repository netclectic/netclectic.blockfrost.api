using Polly;
using RestEase;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace netclectic.blockfrost.api
{
    public class CustomHttpClientHandler : HttpClientHandler
    {
        public event EventHandler<RequestSent> SendRequest;
        public event EventHandler<ResponseReceived> ReceiveResponse;

        private void OnSendRequest(RequestSent requestSent)
        {
            try
            {
                SendRequest?.Invoke(this, requestSent);
            }
            catch { }
        }

        private void OnReceiveResponse(ResponseReceived responseReceived)
        {
            try
            {
                ReceiveResponse?.Invoke(this, responseReceived);
            }
            catch { }
        }

        public CustomHttpClientHandler(IWebProxy proxy = null)
        {
            Proxy = proxy;
            ServerCertificateCustomValidationCallback += (_, __, ___, ____) => true;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string requestId = null;
            if (request.Headers.Contains("request-expects-response"))
            {
                var requestSent = new RequestSent(request.Headers.GetValues("request-expects-response").First());
                requestId = requestSent.Id;
                OnSendRequest(requestSent);
                request.Headers.Remove("request-expects-response");
            }

            int maxRetryAttempts = 0;
            var pauseBetweenFailures = TimeSpan.FromSeconds(2);
            if (request.Headers.Contains("request-retry-count"))
            {
                maxRetryAttempts = int.Parse(request.Headers.GetValues("request-retry-count").First());
                if (request.Headers.Contains("request-retry-wait"))
                {
                    pauseBetweenFailures = TimeSpan.FromSeconds(int.Parse(request.Headers.GetValues("request-retry-wait").First()));
                    request.Headers.Remove("request-retry-count");
                }
                request.Headers.Remove("request-retry-wait");
            }

            var retryPolicy = Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(maxRetryAttempts, _ => pauseBetweenFailures);

            return retryPolicy.ExecuteAsync(async () =>
            {
                var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
                var requestInfo = (IRequestInfo)request.Properties[RestClient.HttpRequestMessageRequestInfoPropertyKey];

                // only throw an exception here if retry attempts are enablef for this request
                if ((maxRetryAttempts > 0) || !requestInfo.AllowAnyStatusCode)
                    response.EnsureSuccessStatusCode();

                if (!string.IsNullOrWhiteSpace(requestId))
                {
                    OnReceiveResponse(new ResponseReceived(requestId));
                }

                return response;
            });
        }
    }
}