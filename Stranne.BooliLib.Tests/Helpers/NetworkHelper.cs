using System;
using System.Net.Http;
using Moq;
using Stranne.BooliLib.Services;
using Stranne.BooliLib.Tests.Json;

namespace Stranne.BooliLib.Tests.Helpers
{
    public class NetworkHelper
    {
        internal static (Mock<NetworkService> mockNetworkService, MockHttpMessageHandler mockHttpMessageHandler)
            SetUpNetworkServiceMock(string absoluteUrl, JsonFile jsonFile)
        {
            var json = JsonHelper.GetJson(jsonFile);
            var httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent(json)
            };
            return SetUpNetworkServiceMock(absoluteUrl, httpResponseMessage);
        }

        internal static (Mock<NetworkService> mockNetworkService, MockHttpMessageHandler mockHttpMessageHandler)
            SetUpNetworkServiceMock(string absoluteUrl, HttpResponseMessage httpResponseMessage)
        {
            var httpMessageHandler = new MockHttpMessageHandler
            {
                SendAssyncAction = (httpRequestMessage, cancellationToken) =>
                {
                    var uri = httpRequestMessage.RequestUri;
                    if (!CompareUri(uri, absoluteUrl) || httpRequestMessage.Method != HttpMethod.Get)
                    {
                        throw new ArgumentException(
                            $"Incorrect url; expected: {absoluteUrl}, actual: {RemoveAuthenticationQueries(uri.AbsoluteUri)}");
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
            return Uri.Compare(new Uri(RemoveAuthenticationQueries(uri.AbsoluteUri)),
                new Uri(absoluteUrl),
                UriComponents.AbsoluteUri, UriFormat.SafeUnescaped,
                StringComparison.OrdinalIgnoreCase) == 0;
        }
        
        public static string RemoveAuthenticationQueries(string url)
        {
            if (url.Contains("callerId"))
            {
                url = url.Substring(0, url.IndexOf("callerId", StringComparison.OrdinalIgnoreCase) - 1);
            }

            return url;
        }
    }
}
