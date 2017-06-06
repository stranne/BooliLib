namespace Stranne.BooliLib.Extension
{
    internal static class ObjectExtension
    {
        public static bool IsNull<T>(this T obj)
        {
            var str = obj as string;
            if (str != null)
            {
                return string.IsNullOrWhiteSpace(str) || str == "null";
            }

            return obj == null;
        }
    }
}
