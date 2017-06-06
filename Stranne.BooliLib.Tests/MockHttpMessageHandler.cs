using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stranne.BooliLib.Tests.Helpers;
using Xunit;

namespace Stranne.BooliLib.Tests
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly object _requestLock = new object();

        private readonly IDictionary<KeyValuePair<string, HttpMethod>, int> _request = new Dictionary<KeyValuePair<string, HttpMethod>, int>();

        public Func<HttpRequestMessage, CancellationToken, HttpResponseMessage> SendAssyncAction { get; set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            SaveRequest(request);
            return await Task.FromResult(SendAssyncAction.Invoke(request, cancellationToken));
        }

        private void SaveRequest(HttpRequestMessage request)
        {
            var url = NetworkHelper.RemoveAuthenticationQueries(request.RequestUri.AbsoluteUri);
            
            var key = new KeyValuePair<string, HttpMethod>(url, request.Method);
            lock (_requestLock)
            {
                if (_request.TryGetValue(key, out int requestedTimes))
                {
                    _request[key] = ++requestedTimes;
                }
                else
                {
                    _request.Add(key, 1);
                }
            }
        }

        public void VerifyRequest(string absoluteUrl, HttpMethod httpMethod, int expectedRequestedTimes = 1)
        {
            absoluteUrl = NetworkHelper.RemoveAuthenticationQueries(absoluteUrl);
            var key = new KeyValuePair<string, HttpMethod>(absoluteUrl, httpMethod);
            int requestedTimes;
            lock (_requestLock)
            {
                _request.TryGetValue(key, out requestedTimes);
            }

            Assert.True(expectedRequestedTimes == requestedTimes, $"Expected {expectedRequestedTimes} calls but found {requestedTimes} calls for request {httpMethod.Method} {absoluteUrl}");
        }
    }
}
