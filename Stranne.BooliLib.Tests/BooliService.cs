using Xunit;
using Stranne.BooliLib;

namespace Stranne.BooliLib.Tests
{
    public class BooliServiceTest
    {
        [Fact]
        public void Test1()
        {
            new BooliService("", "");
        }

        [Fact]
        public void Dispose()
        {
            new BooliService(TestConstants.CallerId, TestConstants.Key).Dispose();
        }
    }
}
