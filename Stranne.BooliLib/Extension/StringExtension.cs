using System.Text.RegularExpressions;

namespace Stranne.BooliLib.Extension
{
    internal static class StringExtension
    {
        public static string ToCamelCase(this string str)
        {
            return Regex.Replace(str, @"^\p{L}", s => s.ToString().ToLower());
        }
    }
}
