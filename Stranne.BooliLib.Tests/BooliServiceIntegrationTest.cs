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
    }
}
