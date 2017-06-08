using System.Linq;
using Stranne.BooliLib.Models;
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
            var searchOption = new ListedSearchOption
            {
                Query = "nacka"
            };
            
            var actual = sut.GetListed(searchOption);

            VerifyRequest();
            Assert.NotNull(actual);
            Assert.Equal(5, actual.Result.Count());
            Assert.Equal(2347066, actual.Result.First().BooliId);
        }

        [Fact]
        public void GetSold()
        {
            const int booliId = 181051;
            const string absoluteUrl = "https://api.booli.se/sold/181051";
            var sut = SetUpTest(absoluteUrl, JsonFile.SoldSingle);

            var actual = sut.GetSold(booliId);

            VerifyRequest();
            Assert.NotNull(actual);
            Assert.Equal(booliId, actual.BooliId);
        }

        [Fact]
        public void GetSoldList()
        {
            const string absoluteUrl = "https://api.booli.se/sold?q=nacka";
            var sut = SetUpTest(absoluteUrl, JsonFile.SoldMultiple);
            var searchOption = new SoldSearchOption
            {
                Query = "nacka"
            };

            var actual = sut.GetSold(searchOption);

            VerifyRequest();
            Assert.NotNull(actual);
            Assert.Equal(5, actual.Result.Count());
            Assert.Equal(2330048, actual.Result.First().BooliId);
        }

        [Fact]
        public void GetArea()
        {
            const string absoluteUrl = "https://api.booli.se/areas?q=nacka";
            var sut = SetUpTest(absoluteUrl, JsonFile.Area);
            var searchOption = new AreaSearchOption
            {
                Query = "nacka"
            };

            var actual = sut.GetArea(searchOption);

            VerifyRequest();
            Assert.NotNull(actual);
            Assert.Equal(5, actual.Result.Count());
            Assert.Equal(76, actual.Result.First().BooliId);
        }
    }
}
