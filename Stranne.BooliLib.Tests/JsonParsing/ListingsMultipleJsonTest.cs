using System;
using Stranne.BooliLib.Tests.Json;
using Stranne.BooliLib.Tests.Models;
using Xunit;

namespace Stranne.BooliLib.Tests.JsonParsing
{
    public class ListingsMultipleJsonTest : BaseJsonTest
    {
        protected override JsonFile JsonFile => JsonFile.ListingsMultiple;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "Listings", 5 },
            { "Listings[0].BooliId", 2347066 },
            { "Listings[0].ListPrice", 1275000d },
            { "Listings[0].Published", new DateTimeOffset(2017, 6, 6, 18, 54, 37, new TimeSpan(2, 0, 0)) },

            { "Listings[0].Source.Id", 115712249 },
            { "Listings[0].Source.Name", "Classic Home Fastighetsmäkleri" },
            { "Listings[0].Source.Url", "http://www.classichome.se/" },
            { "Listings[0].Source.Type", "Broker" },

            { "Listings[0].Location.NamedAreas", 1 },
            { "Listings[0].Location.NamedAreas[0]", "Saltsjöbaden" },
            { "Listings[0].Location.Address.StreetAddress", "Karl Gerhards väg 23" },
            { "Listings[0].Location.Address.City", null },
            { "Listings[0].Location.Region.MunicipalityName", "Nacka" },
            { "Listings[0].Location.Region.CountyName", "Stockholms län" },
            { "Listings[0].Location.Position.Latitude", 59.27452078d },
            { "Listings[0].Location.Position.Longitude", 18.30574393d },
            { "Listings[0].Location.Position.IsApproximate", null },
            { "Listings[0].Location.Distance.Ocean", null },

            { "Listings[0].ObjectType", "Lägenhet" },
            { "Listings[0].Rooms", 1f },
            { "Listings[0].LivingArea", 24f },
            { "Listings[0].AdditionalArea", null },
            { "Listings[0].PlotArea", null },
            { "Listings[0].Rent", 1353f },
            { "Listings[0].Floor", null },
            { "Listings[0].ApartmentNumber", null },
            { "Listings[0].ConstructionYear", 1964 },
            { "Listings[0].Url", "https://www.booli.se/annons/2347066" },
            { "Listings[0].Pageviews", null },



            { "Listings[1].BooliId", 2341646 },
            { "Listings[1].ListPrice", 2195000d },
            { "Listings[1].Published", new DateTimeOffset(2017, 6, 6, 1, 3, 21, new TimeSpan(2, 0, 0)) },

            { "Listings[1].Source.Id", 58 },
            { "Listings[1].Source.Name", "Svenska Mäklarhuset" },
            { "Listings[1].Source.Url", "http://www.svenskamaklarhuset.se/" },
            { "Listings[1].Source.Type", "Broker" },

            { "Listings[1].Location.NamedAreas", 1 },
            { "Listings[1].Location.NamedAreas[0]", "Saltsjöbaden" },
            { "Listings[1].Location.Address.StreetAddress", "Ljuskärrsvägen 71" },
            { "Listings[1].Location.Address.City", null },
            { "Listings[1].Location.Region.MunicipalityName", "Nacka" },
            { "Listings[1].Location.Region.CountyName", "Stockholms län" },
            { "Listings[1].Location.Position.Latitude", 59.28495073d },
            { "Listings[1].Location.Position.Longitude", 18.26883674d },
            { "Listings[1].Location.Position.IsApproximate", null },
            { "Listings[1].Location.Distance.Ocean", null },

            { "Listings[1].ObjectType", "Lägenhet" },
            { "Listings[1].Rooms", 2f },
            { "Listings[1].LivingArea", 63.5f },
            { "Listings[1].AdditionalArea", null },
            { "Listings[1].PlotArea", null },
            { "Listings[1].Rent", 3360f },
            { "Listings[1].Floor", 1f },
            { "Listings[1].ApartmentNumber", null },
            { "Listings[1].ConstructionYear", null },
            { "Listings[1].Url", "https://www.booli.se/annons/2341646" },
            { "Listings[1].Pageviews", null },



            { "Listings[2].BooliId", 2343172 },
            { "Listings[2].ListPrice", 2895000d },
            { "Listings[2].Published", new DateTimeOffset(2017, 6, 5, 23, 30, 9, new TimeSpan(2, 0, 0)) },

            { "Listings[2].Source.Id", 1570 },
            { "Listings[2].Source.Name", "SkandiaMäklarna" },
            { "Listings[2].Source.Url", "http://www.skandiamaklarna.se/" },
            { "Listings[2].Source.Type", "Broker" },

            { "Listings[2].Location.NamedAreas", 1 },
            { "Listings[2].Location.NamedAreas[0]", "Finntorp" },
            { "Listings[2].Location.Address.StreetAddress", "Fredrik Jahns gränd 6" },
            { "Listings[2].Location.Address.City", null },
            { "Listings[2].Location.Region.MunicipalityName", "Nacka" },
            { "Listings[2].Location.Region.CountyName", "Stockholms län" },
            { "Listings[2].Location.Position.Latitude", 59.30770373d },
            { "Listings[2].Location.Position.Longitude", 18.13700112d },
            { "Listings[2].Location.Position.IsApproximate", null },
            { "Listings[2].Location.Distance.Ocean", null },

            { "Listings[2].ObjectType", "Lägenhet" },
            { "Listings[2].Rooms", 2f },
            { "Listings[2].LivingArea", 58f },
            { "Listings[2].AdditionalArea", null },
            { "Listings[2].PlotArea", null },
            { "Listings[2].Rent", 2780f },
            { "Listings[2].Floor", null },
            { "Listings[2].ApartmentNumber", null },
            { "Listings[2].ConstructionYear", 1951 },
            { "Listings[2].Url", "https://www.booli.se/annons/2343172" },
            { "Listings[2].Pageviews", null },
            


            { "Listings[3].BooliId", 2346696 },
            { "Listings[3].ListPrice", 16900000d },
            { "Listings[3].Published", new DateTimeOffset(2017, 6, 5, 19, 28, 22, new TimeSpan(2, 0, 0)) },

            { "Listings[3].Source.Id", 300 },
            { "Listings[3].Source.Name", "Schneider & Co AB" },
            { "Listings[3].Source.Url", "http://www.schneiderco.se/" },
            { "Listings[3].Source.Type", "Broker" },

            { "Listings[3].Location.NamedAreas", 1 },
            { "Listings[3].Location.NamedAreas[0]", "Södra Lännersta" },
            { "Listings[3].Location.Address.StreetAddress", "Örnbergsstigen 6" },
            { "Listings[3].Location.Address.City", null },
            { "Listings[3].Location.Region.MunicipalityName", "Nacka" },
            { "Listings[3].Location.Region.CountyName", "Stockholms län" },
            { "Listings[3].Location.Position.Latitude", 59.30379927d },
            { "Listings[3].Location.Position.Longitude", 18.24811838d },
            { "Listings[3].Location.Position.IsApproximate", null },
            { "Listings[3].Location.Distance.Ocean", null },

            { "Listings[3].ObjectType", "Villa" },
            { "Listings[3].Rooms", 8f },
            { "Listings[3].LivingArea", 240f },
            { "Listings[3].AdditionalArea", null },
            { "Listings[3].PlotArea", 2022 },
            { "Listings[3].Rent", null },
            { "Listings[3].Floor", null },
            { "Listings[3].ApartmentNumber", null },
            { "Listings[3].ConstructionYear", 2004 },
            { "Listings[3].Url", "https://www.booli.se/annons/2346696" },
            { "Listings[3].Pageviews", null },



            { "Listings[4].BooliId", 2346548 },
            { "Listings[4].ListPrice", 5395000d },
            { "Listings[4].Published", new DateTimeOffset(2017, 6, 5, 16, 7, 45, new TimeSpan(2, 0, 0)) },

            { "Listings[4].Source.Id", 278 },
            { "Listings[4].Source.Name", "Svenska Hem" },
            { "Listings[4].Source.Url", "http://www.sehem.se/" },
            { "Listings[4].Source.Type", "Broker" },

            { "Listings[4].Location.NamedAreas", 1 },
            { "Listings[4].Location.NamedAreas[0]", "Finnboda Hamn" },
            { "Listings[4].Location.Address.StreetAddress", "Finnboda Parkväg 6" },
            { "Listings[4].Location.Address.City", null },
            { "Listings[4].Location.Region.MunicipalityName", "Nacka" },
            { "Listings[4].Location.Region.CountyName", "Stockholms län" },
            { "Listings[4].Location.Position.Latitude", 59.31305129d },
            { "Listings[4].Location.Position.Longitude", 18.12274218d },
            { "Listings[4].Location.Position.IsApproximate", null },
            { "Listings[4].Location.Distance.Ocean", null },

            { "Listings[4].ObjectType", "Lägenhet" },
            { "Listings[4].Rooms", 4f },
            { "Listings[4].LivingArea", 90.5f },
            { "Listings[4].AdditionalArea", 0f },
            { "Listings[4].PlotArea", null },
            { "Listings[4].Rent", 6005f },
            { "Listings[4].Floor", 2f },
            { "Listings[4].ApartmentNumber", null },
            { "Listings[4].ConstructionYear", 2006 },
            { "Listings[4].Url", "https://www.booli.se/annons/2346548" },
            { "Listings[4].Pageviews", null },
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void ListingsMultipleJsonParsing(string property, object expected)
        {
            TestValue<ListingsRoot>(property, expected);
        }
    }
}
