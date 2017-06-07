using System;
using System.Collections.Generic;
using Stranne.BooliLib.ApiModels;
using Stranne.BooliLib.Helpers;
using Xunit;

namespace Stranne.BooliLib.Tests.Helpers
{
    public class QueryHelperTest
    {
        [Fact]
        public void GetQueryBooliBaseSearchOptionAttribute()
        {
            var listedSearchOption = new ListedSearchOption();

            var exception = Assert.Throws<ArgumentException>(() => QueryHelper.GetQuery(listedSearchOption));

            Assert.Null(exception.ParamName);
            Assert.Equal("Make sure to always specify a value for at least one of the following properties; Query", exception.Message);
        }

        [Fact]
        public void GetQuerySerializeDependencyAttribute()
        {
            var listedSearchOption = new ListedSearchOption
            {
                Query = "nacka",
                Dimension = new Dimension(1, 1)
            };

            var exception = Assert.Throws<ArgumentException>(() => QueryHelper.GetQuery(listedSearchOption));

            Assert.Null(exception.ParamName);
            Assert.Equal("'Center' can't be null since it is dependent by 'Dimension'", exception.Message);
        }

        [Fact]
        public void GetQuery()
        {
            var listedSearchOption = new ListedSearchOption
            {
                Center = new Position(57, 12),
                Dimension = new Dimension(1, 1),
                ObjectTypes = new [] { "Lägenhet", "Villa" },
                Query = "nacka"
            };

            var actual = QueryHelper.GetQuery(listedSearchOption);
            
            Assert.Contains(new KeyValuePair<string, string>("objectTypes", "Lägenhet,Villa"), actual);
            Assert.Contains(new KeyValuePair<string, string>("dim", "1,1"), actual);
            Assert.Contains(new KeyValuePair<string, string>("center", "57,12"), actual);
            Assert.Contains(new KeyValuePair<string, string>("q", "nacka"), actual);
        }
    }
}
