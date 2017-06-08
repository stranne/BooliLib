using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Stranne.BooliLib.Models;
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
            var (mockNetworkService, mockHttpMessageHandler) = NetworkHelper.SetUpNetworkServiceMock(TestConstants.AbsoluteListingsUrl, JsonFile.ListingsSingle);
            var sut = GetBaseService();
            sut.NetworkService = mockNetworkService.Object;

            var actual = await sut.GetAsync<ListedObject>("listings", 2338291);

            mockHttpMessageHandler.VerifyRequest(TestConstants.AbsoluteListingsUrl, HttpMethod.Get);
            Assert.NotNull(actual);
            Assert.Equal(actual.BooliId, 2338291);
        }

        [Fact]
        public async Task GetAsyncMultiple()
        {
            const string absoluteUrl = "https://api.booli.se/listings?q=nacka";
            var (mockNetworkService, mockHttpMessageHandler) = NetworkHelper.SetUpNetworkServiceMock(absoluteUrl, JsonFile.ListingsMultiple);
            var sut = GetBaseService();
            sut.NetworkService = mockNetworkService.Object;
            var searchOption = new ListedSearchOption
            {
                Query = "nacka"
            };

            var actual = await sut.GetAsync<ListedObject, ListedSearchOption>("listings", searchOption);

            mockHttpMessageHandler.VerifyRequest(absoluteUrl, HttpMethod.Get);
            Assert.NotNull(actual);
            Assert.Equal(849, actual.TotalCount);
            Assert.Equal(5, actual.Count);
            Assert.Equal(5, actual.Limit);
            Assert.Equal(0, actual.Offset);
            //Assert.Equal(0, actual.SearchParameters.UpcomingSale); // TODO ?
            Assert.Contains(76, actual.SearchParameters.AreaId);
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
