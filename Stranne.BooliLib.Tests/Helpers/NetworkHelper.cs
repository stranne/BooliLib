using System;
using System.Net.Http;
using Moq;
using Stranne.BooliLib.Services;

namespace Stranne.BooliLib.Tests.Helpers
{
    public class NetworkHelper
    {
        internal static (Mock<NetworkService> mockNetworkService, MockHttpMessageHandler mockHttpMessageHandler) SetUpNetworkServiceMock(string absoluteUrl, HttpResponseMessage httpResponseMessage)
        {
            var httpMessageHandler = new MockHttpMessageHandler
            {
                SendAssyncAction = (httpRequestMessage, cancellationToken) =>
                {
                    var uri = httpRequestMessage.RequestUri;
                    if (!CompareUri(uri, absoluteUrl) || httpRequestMessage.Method != HttpMethod.Get)
                    {
                        throw new ArgumentException(
                            $"Incorrect url; expected: {absoluteUrl}, actual: {uri.AbsoluteUri}");
                    }

                    return httpResponseMessage;
                }
            };

            var mockNetworkService = new Mock<NetworkService>();
            mockNetworkService.SetupProperty(networkService => networkService.HttpClient, new HttpClient(httpMessageHandler));

            return (mockNetworkService, httpMessageHandler);
        }

        internal static bool CompareUri(Uri uri, string absoluteUrl)
        {
            return Uri.Compare(uri,
                new Uri(absoluteUrl),
                UriComponents.AbsoluteUri, UriFormat.SafeUnescaped,
                StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
