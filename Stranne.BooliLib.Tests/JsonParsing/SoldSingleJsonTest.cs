using System;
using Stranne.BooliLib.Tests.Json;
using Stranne.BooliLib.Tests.Models;
using Xunit;

namespace Stranne.BooliLib.Tests.JsonParsing
{
    public class SoldSingleJsonTest : BaseJsonTest
    {
        protected override JsonFile JsonFile => JsonFile.SoldSingle;
        
        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "Sold", 1 },
            { "Sold[0].BooliId", 181051 },
            { "Sold[0].ListPrice", 1695000d },
            { "Sold[0].Published", new DateTimeOffset(2012, 6, 14, 15, 30, 55, new TimeSpan(2, 0, 0)) },
            { "Sold[0].SoldPrice", 1680000d },
            { "Sold[0].SoldDate", new DateTimeOffset(2012, 11, 6, 0, 0, 0, new TimeSpan(1, 0, 0)) },

            { "Sold[0].Source.Id", 713 },
            { "Sold[0].Source.Name", "Svensk Fastighetsförmedling" },
            { "Sold[0].Source.Url", "http://www.svenskfast.se/" },
            { "Sold[0].Source.Type", "Broker" },

            { "Sold[0].Location.NamedAreas", 1 },
            { "Sold[0].Location.NamedAreas[0]", "Hässelby Strand" },
            { "Sold[0].Location.Address.StreetAddress", "Aprikosgatan 29" },
            { "Sold[0].Location.Region.MunicipalityName", "Stockholm" },
            { "Sold[0].Location.Region.CountyName", "Stockholms län" },
            { "Sold[0].Location.Position.Latitude", 59.3599487d },
            { "Sold[0].Location.Position.Longitude", 17.8377649 },
            { "Sold[0].Location.Position.IsApproximate", true },

            { "Sold[0].ObjectType", "Lägenhet" },
            { "Sold[0].Rooms", 3f },
            { "Sold[0].LivingArea", 73f },
            { "Sold[0].AdditionalArea", null },
            { "Sold[0].PlotArea", null },
            { "Sold[0].Rent", 4213f },
            { "Sold[0].Floor", 6f },
            { "Sold[0].ConstructionYear", 1957 },
            { "Sold[0].Url", "https://www.booli.se/annons/181051" }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void SoldSingleJsonParsing(string property, object expected)
        {
            TestValue<SoldRoot>(property, expected);
        }
    }
}
