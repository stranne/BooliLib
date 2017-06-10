using System;
using System.Collections.Generic;
using System.Reflection;
using Stranne.BooliLib.Helpers;
using Stranne.BooliLib.Models;
using Stranne.BooliLib.Tests.Models;
using Xunit;

namespace Stranne.BooliLib.Tests.Helpers
{
    [Trait("Area", "Helpers")]
    public class QueryHelperTest
    {
        [Fact]
        public void GetQueryBooliBaseSearchOptionAttribute()
        {
            var searchOption = new ListedSearchOption();

            var exception = Assert.Throws<ArgumentException>(() => QueryHelper.GetQuery(searchOption));

            Assert.Null(exception.ParamName);
            Assert.Equal("Make sure to always specify a value for at least one of the following properties; Query", exception.Message);
        }

        [Fact]
        public void GetQuerySerializeDependencyAttribute()
        {
            var searchOption = new ListedSearchOption
            {
                Query = "nacka",
                Dimension = new Dimension(1, 1)
            };

            var exception = Assert.Throws<ArgumentException>(() => QueryHelper.GetQuery(searchOption));

            Assert.Null(exception.ParamName);
            Assert.Equal("'Center' can't be null since it is dependent by 'Dimension'", exception.Message);
        }

        [Fact]
        public void GetQuery()
        {
            var searchOption = new ListedSearchOption
            {
                Center = new Position(57, 12),
                Dimension = new Dimension(1, 1),
                ObjectTypes = new [] { "Lägenhet", "Villa" },
                Query = "nacka"
            };

            var actual = QueryHelper.GetQuery(searchOption);
            
            Assert.Contains(new KeyValuePair<string, string>("objectTypes", "lägenhet,villa"), actual);
            Assert.Contains(new KeyValuePair<string, string>("dim", "1,1"), actual);
            Assert.Contains(new KeyValuePair<string, string>("center", "57,12"), actual);
            Assert.Contains(new KeyValuePair<string, string>("q", "nacka"), actual);
        }

        public static TheoryData GetQueryListedMemberData = new TheoryData<string, object, string, string>
        {
            { nameof(ListedSearchOption.PriceDecrease), true, "priceDecrease", "1" },
            { nameof(ListedSearchOption.PriceDecrease), false, "priceDecrease", "0" },
            { nameof(ListedSearchOption.AreaId), new[] { 1, 2 }, "areaId", "1,2" },
            { nameof(ListedSearchOption.BoxCoordinates), new BoxCoordinatesSerializable(52, 17, 53, 18), "bbox", "52,17,53,18" },
            { nameof(ListedSearchOption.Center), new PositionSerializable(52, 17), "center", "52,17" },
            { nameof(ListedSearchOption.IncludeUnset), true, "includeUnset", "1" },
            { nameof(ListedSearchOption.IncludeUnset), false, "includeUnset", "0" },
            { nameof(ListedSearchOption.MaxConstructionYear), 2010, "maxConstructionYear", "2010" },
            { nameof(ListedSearchOption.MinConstructionYear), 2000, "minConstructionYear", "2000" },
            { nameof(ListedSearchOption.MaxListPrice), 10000000d, "maxListPrice", "10000000.0" },
            { nameof(ListedSearchOption.MinListPrice), 8000000d, "minListPrice", "8000000.0" },
            { nameof(ListedSearchOption.MaxListSqmPrice), 100000d, "maxListSqmPrice", "100000.0" },
            { nameof(ListedSearchOption.MinListSqmPrice), 30000d, "minListSqmPrice", "30000.0" },
            { nameof(ListedSearchOption.MaxLivingArea), 160f, "maxLivingArea", "160.0" },
            { nameof(ListedSearchOption.MinLivingArea), 40f, "minLivingArea", "40.0" },
            { nameof(ListedSearchOption.MaxPlotArea), 1000f, "maxPlotArea", "1000.0" },
            { nameof(ListedSearchOption.MinPlotArea), 10f, "minPlotArea", "10.0" },
            { nameof(ListedSearchOption.MaxPublished), new DateTimeOffset(2010, 12, 31, 0, 0, 0, new TimeSpan(1, 0, 0)), "maxPublished", "20101231" },
            { nameof(ListedSearchOption.MinPublished),  new DateTimeOffset(2010, 1, 1, 0, 0, 0, new TimeSpan(1, 0, 0)), "minPublished", "20100101" },
            { nameof(ListedSearchOption.MaxRent), 5000f, "maxRent", "5000.0" },
            { nameof(ListedSearchOption.MaxRooms), 10f, "maxRooms", "10.0" },
            { nameof(ListedSearchOption.MinRooms), 2f, "minRooms", "2.0" },
            { nameof(ListedSearchOption.ObjectTypes), new[] { "Lägenhet", "Villa" }, "objectTypes", "lägenhet,villa" },
            { nameof(ListedSearchOption.Limit), 10, "limit", "10" },
            { nameof(ListedSearchOption.Offset), 2, "offset", "2" }
        };

        [Theory]
        [MemberData(nameof(GetQueryListedMemberData))]
        public void GetQueryListed(string name, object value, string expectedName, string expectedValue)
        {
            GetQuery<ListedSearchOption>(name, value, expectedName, expectedValue);
        }
        
        public static TheoryData GetQuerySoldMemberData = new TheoryData<string, object, string, string>
        {
            { nameof(SoldSearchOption.MinSoldPrice), 50000000d, "minSoldPrice", "50000000.0" },
            { nameof(SoldSearchOption.MaxSoldPrice), 1000000d, "maxSoldPrice", "1000000.0" },
            { nameof(SoldSearchOption.MinSoldSqmPrice), 500d, "minSoldSqmPrice", "500.0" },
            { nameof(SoldSearchOption.MaxSoldSqmPrice), 10.951d, "maxSoldSqmPrice", "10.951" },
            { nameof(SoldSearchOption.MinSoldDate), new DateTimeOffset(2010, 1, 1, 0, 0, 0, new TimeSpan(1, 0, 0)), "minSoldDate", "20100101" },
            { nameof(SoldSearchOption.MaxSoldDate), new DateTimeOffset(2010, 12, 31, 0, 0, 0, new TimeSpan(1, 0, 0)), "maxSoldDate", "20101231" },
            { nameof(SoldSearchOption.AreaId), new[] { 1, 2 }, "areaId", "1,2" },
            { nameof(SoldSearchOption.BoxCoordinates), new BoxCoordinatesSerializable(52, 17, 53, 18), "bbox", "52,17,53,18" },
            { nameof(SoldSearchOption.Center), new PositionSerializable(52, 17), "center", "52,17" },
            { nameof(SoldSearchOption.IncludeUnset), true, "includeUnset", "1" },
            { nameof(SoldSearchOption.IncludeUnset), false, "includeUnset", "0" },
            { nameof(SoldSearchOption.MaxConstructionYear), 2010, "maxConstructionYear", "2010" },
            { nameof(SoldSearchOption.MinConstructionYear), 2000, "minConstructionYear", "2000" },
            { nameof(SoldSearchOption.MaxListPrice), 10000000d, "maxListPrice", "10000000.0" },
            { nameof(SoldSearchOption.MinListPrice), 8000000d, "minListPrice", "8000000.0" },
            { nameof(SoldSearchOption.MaxListSqmPrice), 100000d, "maxListSqmPrice", "100000.0" },
            { nameof(SoldSearchOption.MinListSqmPrice), 30000d, "minListSqmPrice", "30000.0" },
            { nameof(SoldSearchOption.MaxLivingArea), 160f, "maxLivingArea", "160.0" },
            { nameof(SoldSearchOption.MinLivingArea), 40f, "minLivingArea", "40.0" },
            { nameof(SoldSearchOption.MaxPlotArea), 1000f, "maxPlotArea", "1000.0" },
            { nameof(SoldSearchOption.MinPlotArea), 10f, "minPlotArea", "10.0" },
            { nameof(SoldSearchOption.MaxPublished), new DateTimeOffset(2010, 12, 31, 0, 0, 0, new TimeSpan(1, 0, 0)), "maxPublished", "20101231" },
            { nameof(SoldSearchOption.MinPublished),  new DateTimeOffset(2010, 1, 1, 0, 0, 0, new TimeSpan(1, 0, 0)), "minPublished", "20100101" },
            { nameof(SoldSearchOption.MaxRent), 5000.95f, "maxRent", "5000.95" },
            { nameof(SoldSearchOption.MaxRooms), 10f, "maxRooms", "10.0" },
            { nameof(SoldSearchOption.MinRooms), 2.5f, "minRooms", "2.5" },
            { nameof(SoldSearchOption.ObjectTypes), new[] { "Lägenhet", "Villa" }, "objectTypes", "lägenhet,villa" },
            { nameof(SoldSearchOption.Limit), 10, "limit", "10" },
            { nameof(SoldSearchOption.Offset), 2, "offset", "2" }
        };

        [Theory]
        [MemberData(nameof(GetQuerySoldMemberData))]
        public void GetQuerySold(string name, object value, string expectedName, string expectedValue)
        {
            GetQuery<SoldSearchOption>(name, value, expectedName, expectedValue);
        }
        
        public static TheoryData GetQueryAreaMemberData = new TheoryData<string, object, string, string>
        {
            { nameof(AreaSearchOption.Position), new PositionSerializable(57, 12), "position", "57,12" },
            { nameof(AreaSearchOption.Listings), false, "listings", "0" },
            { nameof(AreaSearchOption.Listings), true, "listings", "1" },
            { nameof(AreaSearchOption.Transactions), false, "transactions", "0" },
            { nameof(AreaSearchOption.Transactions), true, "transactions", "1" },
            { nameof(AreaSearchOption.Limit), 10, "limit", "10" },
        };

        [Theory]
        [MemberData(nameof(GetQueryAreaMemberData))]
        public void GetQueryArea(string name, object value, string expectedName, string expectedValue)
        {
            GetQuery<AreaSearchOption>(name, value, expectedName, expectedValue);
        }

        private static void GetQuery<TSearchOptions>(string name, object value, string expectedName, string expectedValue)
            where TSearchOptions : BaseSearchOptions
        {
            var searchOption = Activator.CreateInstance<TSearchOptions>();
            searchOption.Query = "nacka";
            searchOption
                .GetType()
                .GetProperty(name)
                .SetValue(searchOption, value);

            var actual = QueryHelper.GetQuery(searchOption);

            Assert.Equal(2, actual.Count);
            Assert.Contains(new KeyValuePair<string, string>("q", "nacka"), actual);
            Assert.Contains(new KeyValuePair<string, string>(expectedName, expectedValue), actual);
        }
    }
}
