using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Stranne.BooliLib.Models;
using Xunit;

namespace Stranne.BooliLib.Tests
{
    public class LibraryVisabilityTest
    {
        private readonly IEnumerable<Type> _publicClasses = new List<Type>
        {
            typeof(BooliService),
            typeof(IBooliService),
            typeof(Address),
            typeof(Area),
            typeof(AreaSearchOption),
            typeof(BaseObjectSearchOptions),
            typeof(BaseResult),
            typeof(BaseSearchOptions),
            typeof(BooliResult<,>),
            typeof(BoxCoordinates),
            typeof(Dimension),
            typeof(Distance),
            typeof(IBooliId),
            typeof(ListedObject),
            typeof(ListedSearchOption),
            typeof(LocationResult),
            typeof(Position),
            typeof(PositionResult),
            typeof(Region),
            typeof(SoldObject),
            typeof(SoldSearchOption),
            typeof(Source)
        };

        [Fact]
        public void VerifyPublicClasses()
        {
            var publicClasses = new List<Type>(_publicClasses);

            var booliLibAssembly = typeof(BooliService).GetTypeInfo().Assembly;
            booliLibAssembly.GetTypes()
                .Where(type => type.GetTypeInfo().IsPublic)
                .ToList()
                .ForEach(type =>
                {
                    Assert.Contains(type, publicClasses);
                    publicClasses.Remove(type);
                });

            Assert.Empty(publicClasses);
        }

        [Fact]
        public void VerifyBooliServiceClassVariables()
        {
            Assert.True(new BooliService(TestConstants.CallerId, TestConstants.Key).BaseService.GetType().GetTypeInfo().IsNotPublic);
        }
    }
}
