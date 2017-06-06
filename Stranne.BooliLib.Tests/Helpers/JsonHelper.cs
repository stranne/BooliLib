using System.IO;
using Stranne.BooliLib.Tests.Json;

namespace Stranne.BooliLib.Tests.Helpers
{
    public static class JsonHelper
    {
        public static string GetJson(JsonFile jsonFile)
        {
            var fileName = $"{jsonFile}.json";
            var json = File.ReadAllText($@"Json\{fileName}");
            return json;
        }
    }
}
