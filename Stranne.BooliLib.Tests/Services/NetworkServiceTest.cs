using System.Net.Http;
using System.Threading.Tasks;
using Stranne.BooliLib.Tests.Helpers;
using Xunit;

namespace Stranne.BooliLib.Tests.Services
{
    [Trait("Area", "Services")]
    public class NetworkServiceTest
    {
        [Theory]
        [InlineData(TestConstants.AbsoluteUrl, TestConstants.TestData)]
        public async Task DownloadStringAsync(string absoluteUrl, string json)
        {
            var httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent(json)
            };
            var (mockNetworkService, mockHttpMessageHandler) = NetworkHelper.SetUpNetworkServiceMock(absoluteUrl, httpResponseMessage);
            var sut = mockNetworkService.Object;

            var actual = await sut.DownloadStringAsync(absoluteUrl);

            Assert.Equal(json, actual);
            mockHttpMessageHandler.VerifyRequest(absoluteUrl, HttpMethod.Get);
        }
    }
}
