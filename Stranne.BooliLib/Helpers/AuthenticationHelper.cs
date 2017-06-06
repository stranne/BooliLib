using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Stranne.BooliLib.Helpers
{
    internal static class AuthenticationHelper
    {
        public static IDictionary<string, string> GetAuthenticationQuery(string callerId, string key)
        {
            var time = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            var unique = CreateUnique(16);
            var hash = CreateHash(callerId + time + key + unique);

            var authenticationQuery = new Dictionary<string, string>
            {
                {
                    "callerId",
                    callerId
                },
                {
                    "time",
                    time
                },
                {
                    "unique",
                    unique
                },
                {
                    "hash",
                    hash
                }
            };

            return authenticationQuery;
        }

        internal static string CreateHash(string text)
        {
            var bytes = Encoding.ASCII.GetBytes(text);

            byte[] hashedBytes;
            using (var sha1 = SHA1.Create())
            {
                hashedBytes = sha1.ComputeHash(bytes);
            }

            var hashedText = BitConverter.ToString(hashedBytes);
            hashedText = hashedText.Replace("-", "").ToLower();
            return hashedText;
        }

        internal static string CreateUnique(int length)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

            var bytes = new byte[length];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(bytes);
            }

            var unique = new StringBuilder(length);
            foreach (var b in bytes)
            {
                unique.Append(chars[b % chars.Length]);
            }

            return unique.ToString();
        }
    }
}
