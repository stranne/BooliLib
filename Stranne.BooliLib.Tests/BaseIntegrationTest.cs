using System.Net.Http;
using Moq;
using Stranne.BooliLib.Services;
using Stranne.BooliLib.Tests.Helpers;
using Stranne.BooliLib.Tests.Json;

namespace Stranne.BooliLib.Tests
{
    public abstract class BaseIntegrationTest
    {
        private string _absoluteUrl;

        private Mock<NetworkService> _networkServiceMock;

        private MockHttpMessageHandler _httpMessageHandlerMock;

        protected BooliService SetUpTest(string absoluteUrl, JsonFile jsonFile)
        {
            _absoluteUrl = absoluteUrl;

            var (networkServiceMock, httpMessageHandlerMock) = NetworkHelper.SetUpNetworkServiceMock(absoluteUrl, jsonFile);
            _networkServiceMock = networkServiceMock;
            _httpMessageHandlerMock = httpMessageHandlerMock;

            var sut = new BooliService(TestConstants.CallerId, TestConstants.Key);
            sut.BaseService.NetworkService = networkServiceMock.Object;
            return sut;
        }

        protected void VerifyRequest()
        {
            _httpMessageHandlerMock.VerifyRequest(_absoluteUrl, HttpMethod.Get);
        }
    }
}
