using Stranne.BooliLib.Tests.Json;
using Stranne.BooliLib.Tests.Models;
using Xunit;

namespace Stranne.BooliLib.Tests.JsonParsing
{
    public class AreaJsonTest : BaseJsonTest
    {
        protected override JsonFile JsonFile => JsonFile.Area;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "Areas", 5 },
            { "Areas[0].BooliId", 76 },
            { "Areas[0].Name", "Nacka" },
            { "Areas[0].Types", 1 },
            { "Areas[0].Types[0]", "Kommun" },
            { "Areas[0].ParentBooliId", 2 },
            { "Areas[0].ParentName", "Stockholms län" },
            { "Areas[0].ParentTypes", 1 },
            { "Areas[0].ParentTypes[0]", "Län" },
            { "Areas[0].FullName", "Nacka, Stockholms län" },
            { "Areas[0].UrlFriendlyName", "nacka" },

            { "Areas[1].BooliId", 930508 },
            { "Areas[1].Name", "Nacka Strand" },
            { "Areas[1].Types", 1 },
            { "Areas[1].Types[0]", "undefined" },
            { "Areas[1].ParentBooliId", 76 },
            { "Areas[1].ParentName", "Nacka" },
            { "Areas[1].ParentTypes", 1 },
            { "Areas[1].ParentTypes[0]", "Kommun" },
            { "Areas[1].FullName", "Nacka Strand, Nacka" },
            { "Areas[1].UrlFriendlyName", "nacka+strand" },

            { "Areas[2].BooliId", 24617 },
            { "Areas[2].Name", "Nacka Forum" },
            { "Areas[2].Types", 1 },
            { "Areas[2].Types[0]", "undefined" },
            { "Areas[2].ParentBooliId", 76 },
            { "Areas[2].ParentName", "Nacka" },
            { "Areas[2].ParentTypes", 1 },
            { "Areas[2].ParentTypes[0]", "Kommun" },
            { "Areas[2].FullName", "Nacka Forum, Nacka" },
            { "Areas[2].UrlFriendlyName", "nacka+forum" },

            { "Areas[3].BooliId", 106799 },
            { "Areas[3].Name", "Nackagatan" },
            { "Areas[3].Types", 1 },
            { "Areas[3].Types[0]", "Street" },
            { "Areas[3].ParentBooliId", 1 },
            { "Areas[3].ParentName", "Stockholm" },
            { "Areas[3].ParentTypes", 1 },
            { "Areas[3].ParentTypes[0]", "Kommun" },
            { "Areas[3].FullName", "Nackagatan, Stockholm" },
            { "Areas[3].UrlFriendlyName", "nackagatan" },

            { "Areas[4].BooliId", 432369 },
            { "Areas[4].Name", "Nackanäsvägen" },
            { "Areas[4].Types", 1 },
            { "Areas[4].Types[0]", "Street" },
            { "Areas[4].ParentBooliId", 76 },
            { "Areas[4].ParentName", "Nacka" },
            { "Areas[4].ParentTypes", 1 },
            { "Areas[4].ParentTypes[0]", "Kommun" },
            { "Areas[4].FullName", "Nackanäsvägen, Nacka" },
            { "Areas[4].UrlFriendlyName", "nackanasvagen" }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void ListingsMultipleJsonParsing(string property, object expected)
        {
            TestValue<AreaRoot>(property, expected);
        }
    }
}
