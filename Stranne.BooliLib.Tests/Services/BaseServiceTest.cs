using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Stranne.BooliLib.ApiModels;
using Stranne.BooliLib.Services;
using Stranne.BooliLib.Tests.Helpers;
using Stranne.BooliLib.Tests.Json;
using Xunit;

namespace Stranne.BooliLib.Tests.Services
{
    public class BaseServiceTest
    {

        private static BaseService GetBaseService() => new BaseService(TestConstants.CallerId, TestConstants.Key);

        [Fact]
        public async Task GetAsync()
        {
            var json = JsonHelper.GetJson(JsonFiles.ListingsSingle);
            var (mockNetworkService, mockHttpMessageHandler) = NetworkHelper.SetUpNetworkServiceMock(TestConstants.AbsoluteListingsUrl, json);
            var sut = GetBaseService();
            sut.NetworkService = mockNetworkService.Object;

            var actual = await sut.GetAsync<ListingsRoot>("listings", 2338291);

            Assert.NotNull(actual);
            Assert.Equal(actual.Listings.Single().BooliId, 2338291);
            mockHttpMessageHandler.VerifyRequest(TestConstants.AbsoluteListingsUrl, HttpMethod.Get);
        }

        public static IEnumerable<object[]> BuildQueryMemberData => new[]
        {
            new object[]
            {
                new Dictionary<string, string>()
            },
            new object[]
            {
                new Dictionary<string, string>
                {
                    {
                        "firstKey", "firstValue"
                    },
                    {
                        "secondKey", "secondKey"
                    }
                }
            }, 
        };

        [Theory]
        [MemberData(nameof(BuildQueryMemberData))]
        public void BuildQuery(IDictionary<string, string> queries)
        {
            var startingQueries = queries.Count;
            var actual = GetBaseService().BuildQuery(queries);

            queries.ToList().ForEach(query => Assert.Contains($"{query.Key}={query.Value}", actual));
            Assert.Contains($"callerId={TestConstants.CallerId}", actual);
            Assert.Contains("&time=", actual);
            Assert.Contains("&unique=", actual);
            Assert.Contains("&hash=", actual);
            Assert.Equal(startingQueries + 3, actual.Count(c => c == '&'));
        }
    }
}
