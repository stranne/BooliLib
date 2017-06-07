using System;
using Stranne.BooliLib.Tests.Json;
using Stranne.BooliLib.Tests.Models;
using Xunit;

namespace Stranne.BooliLib.Tests.JsonParsing
{
    public class ListingsSingleJsonTest : BaseJsonTest
    {
        protected override JsonFile JsonFile => JsonFile.ListingsSingle;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "Listings", 1 },
            { "Listings[0].BooliId", 2338291 },
            { "Listings[0].ListPrice", 4675000d },
            { "Listings[0].Published", new DateTimeOffset(2017, 05, 26, 15, 21, 30, new TimeSpan(2, 0, 0)) },

            { "Listings[0].Source.Id", 1499 },
            { "Listings[0].Source.Name", "BOSTHLM" },
            { "Listings[0].Source.Url", "http://www.bosthlm.se/" },
            { "Listings[0].Source.Type", "Broker" },

            { "Listings[0].Location.NamedAreas", 1 },
            { "Listings[0].Location.NamedAreas[0]", "Vasastan" },
            { "Listings[0].Location.Address.StreetAddress", "Roslagsgatan 23" },
            { "Listings[0].Location.Address.City", null },
            { "Listings[0].Location.Region.MunicipalityName", "Stockholm" },
            { "Listings[0].Location.Region.CountyName", "Stockholms län" },
            { "Listings[0].Location.Position.Latitude", 59.34733169d },
            { "Listings[0].Location.Position.Longitude", 18.05882873d },
            { "Listings[0].Location.Position.IsApproximate", null },
            { "Listings[0].Location.Distance.Ocean", null },

            { "Listings[0].ObjectType", "Lägenhet" },
            { "Listings[0].Rooms", 2f },
            { "Listings[0].LivingArea", 50.5f },
            { "Listings[0].AdditionalArea", null },
            { "Listings[0].PlotArea", null },
            { "Listings[0].Rent", 2382f },
            { "Listings[0].Floor", 3f },
            { "Listings[0].ApartmentNumber", null },
            { "Listings[0].ConstructionYear", null },
            { "Listings[0].Url", "https://www.booli.se/annons/2338291" },
            { "Listings[0].Pageviews", 55 }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void ListingsSingleJsonParsing(string property, object expected)
        {
            TestValue<ListingsRoot>(property, expected);
        }
    }
}
