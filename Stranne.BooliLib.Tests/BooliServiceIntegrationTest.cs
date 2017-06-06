using System.Linq;
using Stranne.BooliLib.ApiModels;
using Stranne.BooliLib.Tests.Json;
using Xunit;

namespace Stranne.BooliLib.Tests
{
    public class BooliServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void GetListed()
        {
            const int booliId = 2338291;
            const string absoluteUrl = "https://api.booli.se/listings/2338291";
            var sut = SetUpTest(absoluteUrl, JsonFile.ListingsSingle);

            var actual = sut.GetListed(booliId);

            VerifyRequest();
            Assert.NotNull(actual);
            Assert.Equal(booliId, actual.BooliId);
        }

        [Fact]
        public void GetListedList()
        {
            const string absoluteUrl = "https://api.booli.se/listings?q=nacka";
            var sut = SetUpTest(absoluteUrl, JsonFile.ListingsMultiple);
            var listedSearchOption = new ListedSearchOption
            {
                Query = "nacka"
            };
            
            var actual = sut.GetListed(listedSearchOption);

            VerifyRequest();
            Assert.NotNull(actual);
            Assert.Equal(5, actual.Result.Count());
            Assert.Equal(2347066, actual.Result.First().BooliId);
        }
    }
}
