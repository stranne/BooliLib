using System;
using Stranne.BooliLib.Tests.Json;
using Stranne.BooliLib.Tests.Models;
using Xunit;

namespace Stranne.BooliLib.Tests.JsonParsing
{
    [Trait("Area", "Json")]
    public class SoldMultipleJsonTest : BaseJsonTest
    {
        protected override JsonFile JsonFile => JsonFile.SoldMultiple;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "Sold", 5 },
            { "Sold[0].BooliId", 2330048 },
            { "Sold[0].ListPrice", 6750000d },
            { "Sold[0].Published", new DateTimeOffset(2017, 5, 17, 18, 41, 32, new TimeSpan(2, 0, 0)) },
            { "Sold[0].SoldPrice", 7560000d },
            { "Sold[0].SoldDate", new DateTimeOffset(2017, 6, 7, 0, 0, 0, new TimeSpan(2, 0, 0)) },

            { "Sold[0].Source.Id", 713 },
            { "Sold[0].Source.Name", "Svensk Fastighetsförmedling" },
            { "Sold[0].Source.Url", "http://www.svenskfast.se/" },
            { "Sold[0].Source.Type", "Broker" },

            { "Sold[0].Location.NamedAreas", 1 },
            { "Sold[0].Location.NamedAreas[0]", "Saltsjö-Boo" },
            { "Sold[0].Location.Address.StreetAddress", "Solhöjdsvägen 20" },
            { "Sold[0].Location.Address.City", null },
            { "Sold[0].Location.Region.MunicipalityName", "Nacka" },
            { "Sold[0].Location.Region.CountyName", "Stockholms län" },
            { "Sold[0].Location.Position.Latitude", 59.31640539d },
            { "Sold[0].Location.Position.Longitude", 18.23623381d },
            { "Sold[0].Location.Position.IsApproximate", null },
            { "Sold[0].Location.Distance.Ocean", 663d },

            { "Sold[0].ObjectType", "Villa" },
            { "Sold[0].Rooms", 4f },
            { "Sold[0].LivingArea", 130f },
            { "Sold[0].AdditionalArea", 30f },
            { "Sold[0].PlotArea", 1454 },
            { "Sold[0].Rent", null },
            { "Sold[0].Floor", null },
            { "Sold[0].ApartmentNumber", null },
            { "Sold[0].ConstructionYear", 1918 },
            { "Sold[0].Url", "https://www.booli.se/annons/2330048" },



            { "Sold[1].BooliId", 2310374 },
            { "Sold[1].ListPrice", 2975000d },
            { "Sold[1].Published", new DateTimeOffset(2017, 4, 27, 13, 12, 7, new TimeSpan(2, 0, 0)) },
            { "Sold[1].SoldPrice", 2935000d },
            { "Sold[1].SoldDate", new DateTimeOffset(2017, 6, 7, 0, 0, 0, new TimeSpan(2, 0, 0)) },

            { "Sold[1].Source.Id", 1564 },
            { "Sold[1].Source.Name", "Erik Olsson Fastighetsförmedling" },
            { "Sold[1].Source.Url", "http://www.erikolsson.se/" },
            { "Sold[1].Source.Type", "Broker" },

            { "Sold[1].Location.NamedAreas", 1 },
            { "Sold[1].Location.NamedAreas[0]", "Jarlaberg" },
            { "Sold[1].Location.Address.StreetAddress", "Diligensvägen 34B" },
            { "Sold[1].Location.Address.City", null },
            { "Sold[1].Location.Region.MunicipalityName", "Nacka" },
            { "Sold[1].Location.Region.CountyName", "Stockholms län" },
            { "Sold[1].Location.Position.Latitude", 59.31561917d },
            { "Sold[1].Location.Position.Longitude", 18.17181587d },
            { "Sold[1].Location.Position.IsApproximate", null },
            { "Sold[1].Location.Distance.Ocean", 608d },

            { "Sold[1].ObjectType", "Lägenhet" },
            { "Sold[1].Rooms", 2f },
            { "Sold[1].LivingArea", 67f },
            { "Sold[1].AdditionalArea", 0f },
            { "Sold[1].PlotArea", null },
            { "Sold[1].Rent", 4172f },
            { "Sold[1].Floor", 0f },
            { "Sold[1].ApartmentNumber", null },
            { "Sold[1].ConstructionYear", 1988 },
            { "Sold[1].Url", "https://www.booli.se/annons/2310374" },



            { "Sold[2].BooliId", 2331687 },
            { "Sold[2].ListPrice", 2895000d },
            { "Sold[2].Published", new DateTimeOffset(2017, 5, 18, 23, 33, 24, new TimeSpan(2, 0, 0)) },
            { "Sold[2].SoldPrice", 3255000d },
            { "Sold[2].SoldDate", new DateTimeOffset(2017, 6, 6, 0, 0, 0, new TimeSpan(2, 0, 0)) },

            { "Sold[2].Source.Id", 1570 },
            { "Sold[2].Source.Name", "SkandiaMäklarna" },
            { "Sold[2].Source.Url", "http://www.skandiamaklarna.se/" },
            { "Sold[2].Source.Type", "Broker" },

            { "Sold[2].Location.NamedAreas", 1 },
            { "Sold[2].Location.NamedAreas[0]", "Nacka Forum" },
            { "Sold[2].Location.Address.StreetAddress", "Serenadvägen 13B" },
            { "Sold[2].Location.Address.City", null },
            { "Sold[2].Location.Region.MunicipalityName", "Nacka" },
            { "Sold[2].Location.Region.CountyName", "Stockholms län" },
            { "Sold[2].Location.Position.Latitude", 59.31083705d },
            { "Sold[2].Location.Position.Longitude", 18.16596826d },
            { "Sold[2].Location.Position.IsApproximate", null },
            { "Sold[2].Location.Distance.Ocean", 890d },

            { "Sold[2].ObjectType", "Lägenhet" },
            { "Sold[2].Rooms", 2f },
            { "Sold[2].LivingArea", 69f },
            { "Sold[2].AdditionalArea", null },
            { "Sold[2].PlotArea", null },
            { "Sold[2].Rent", 4180f },
            { "Sold[2].Floor", 3f },
            { "Sold[2].ApartmentNumber", null },
            { "Sold[2].ConstructionYear", 2009 },
            { "Sold[2].Url", "https://www.booli.se/annons/2331687" },



            { "Sold[3].BooliId", 2311155 },
            { "Sold[3].ListPrice", 9800000d },
            { "Sold[3].Published", new DateTimeOffset(2017, 4, 28, 3, 49, 56, new TimeSpan(2, 0, 0)) },
            { "Sold[3].SoldPrice", 9400000d },
            { "Sold[3].SoldDate", new DateTimeOffset(2017, 6, 6, 0, 0, 0, new TimeSpan(2, 0, 0)) },

            { "Sold[3].Source.Id", 1314 },
            { "Sold[3].Source.Name", "Eklund Stockholm New York" },
            { "Sold[3].Source.Url", "http://www.esny.se/" },
            { "Sold[3].Source.Type", "Broker" },

            { "Sold[3].Location.NamedAreas", 1 },
            { "Sold[3].Location.NamedAreas[0]", "Finnboda Hamn" },
            { "Sold[3].Location.Address.StreetAddress", "Finnboda Varvsväg 14B" },
            { "Sold[3].Location.Address.City", null },
            { "Sold[3].Location.Region.MunicipalityName", "Nacka" },
            { "Sold[3].Location.Region.CountyName", "Stockholms län" },
            { "Sold[3].Location.Position.Latitude", 59.31560938d },
            { "Sold[3].Location.Position.Longitude", 18.12424451d },
            { "Sold[3].Location.Position.IsApproximate", null },
            { "Sold[3].Location.Distance.Ocean", 85d },

            { "Sold[3].ObjectType", "Lägenhet" },
            { "Sold[3].Rooms", 4f },
            { "Sold[3].LivingArea", 103f },
            { "Sold[3].AdditionalArea", null },
            { "Sold[3].PlotArea", null },
            { "Sold[3].Rent", 5544f },
            { "Sold[3].Floor", 4f },
            { "Sold[3].ApartmentNumber", "1401" },
            { "Sold[3].ConstructionYear", 2014 },
            { "Sold[3].Url", "https://www.booli.se/annons/2311155" },



            { "Sold[4].BooliId", 2321667 },
            { "Sold[4].ListPrice", 4500000d },
            { "Sold[4].Published", new DateTimeOffset(2017, 5, 10, 21, 41, 38, new TimeSpan(2, 0, 0)) },
            { "Sold[4].SoldPrice", 4500000d },
            { "Sold[4].SoldDate", new DateTimeOffset(2017, 6, 6, 0, 0, 0, new TimeSpan(2, 0, 0)) },

            { "Sold[4].Source.Id", 1570 },
            { "Sold[4].Source.Name", "SkandiaMäklarna" },
            { "Sold[4].Source.Url", "http://www.skandiamaklarna.se/" },
            { "Sold[4].Source.Type", "Broker" },

            { "Sold[4].Location.NamedAreas", 1 },
            { "Sold[4].Location.NamedAreas[0]", "Saltsjö-Boo" },
            { "Sold[4].Location.Address.StreetAddress", "Lokevägen 29A" },
            { "Sold[4].Location.Address.City", "Boo" },
            { "Sold[4].Location.Region.MunicipalityName", "Nacka" },
            { "Sold[4].Location.Region.CountyName", "Stockholms län" },
            { "Sold[4].Location.Position.Latitude", 59.31976905d },
            { "Sold[4].Location.Position.Longitude", 18.27640034d },
            { "Sold[4].Location.Position.IsApproximate", null },
            { "Sold[4].Location.Distance.Ocean", 1601d },

            { "Sold[4].ObjectType", "Tomt/Mark" },
            { "Sold[4].Rooms", null },
            { "Sold[4].LivingArea", null },
            { "Sold[4].AdditionalArea", null },
            { "Sold[4].PlotArea", 801 },
            { "Sold[4].Rent", null },
            { "Sold[4].Floor", null },
            { "Sold[4].ApartmentNumber", null },
            { "Sold[4].ConstructionYear", null },
            { "Sold[4].Url", "https://www.booli.se/annons/2321667" },
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void SoldMultipleJsonParsing(string property, object expected)
        {
            TestValue<SoldRoot>(property, expected);
        }
    }
}
