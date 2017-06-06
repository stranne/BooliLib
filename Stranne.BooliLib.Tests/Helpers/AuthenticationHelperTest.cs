using System.Collections.Generic;
using System.Text.RegularExpressions;
using Stranne.BooliLib.Helpers;
using Xunit;

namespace Stranne.BooliLib.Tests.Helpers
{
    [Trait("Area", "Helpers")]
    public class AuthenticationHelperTest
    {
        [Theory]
        [InlineData(TestConstants.CallerId, TestConstants.Key)]
        public void GetAuthenticationQuery(string callerId, string key)
        {
            var actual = AuthenticationHelper.GetAuthenticationQuery(callerId, key);

            Assert.NotEmpty(actual);
            Assert.Contains(new KeyValuePair<string, string>("callerId", callerId), actual);
            Assert.True(actual.ContainsKey("time"));
            Assert.True(actual.ContainsKey("unique"));
            Assert.True(actual.ContainsKey("hash"));
        }

        [Theory]
        [InlineData("abc123", "6367c48dd193d56ea7b0baad25b19455e529f5ee")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi feugiat orci ac arcu vulputate aliquet. In hac habitasse platea dictumst. In enim quam, iaculis a gravida suscipit, volutpat ac ipsum. Curabitur euismod orci sit amet tortor suscipit, eu ultricies felis fermentum. Aenean tincidunt convallis risus ac tempus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Quisque suscipit elit et dignissim semper. Aliquam molestie neque non dui bibendum aliquet. Nunc sed sapien eget velit elementum auctor. Vestibulum turpis quam, efficitur in tempus quis, faucibus id justo. Nam interdum sem a turpis tincidunt maximus. Ut quis nisl sed turpis vulputate sollicitudin. Nulla sit amet arcu iaculis, molestie eros sit amet, bibendum tellus. Cras ut justo turpis. Ut vitae iaculis arcu, sed tempus libero. Quisque et justo metus.", "dafc5ce692c975a0b48cc1c9cca25611690a7174")]
        public void CreateHash(string text, string expected)
        {
            var actual = AuthenticationHelper.CreateHash(text);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(16)]
        public void CreateUniqueLength(int length)
        {
            var actual = AuthenticationHelper.CreateUnique(length);
            Assert.Equal(length, actual.Length);
        }

        [Theory]
        [InlineData(16)]
        public void CreateUniqueCharacters(int length)
        {
            var actual = AuthenticationHelper.CreateUnique(length);
            var regex = new Regex(@"^[a-zA-Z0-9]*$");
            Assert.True(regex.IsMatch(actual));
        }
    }
}
