using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Stranne.BooliLib.Services
{
    internal class NetworkService : IDisposable
    {
        private static readonly Uri BaseAddress = new Uri("https://api.booli.se/");

        internal virtual HttpClient HttpClient { get; set; } = new HttpClient
        {
            BaseAddress = BaseAddress
        };

        public async Task<string> DownloadStringAsync(string path)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(BaseAddress, path),
                Method = HttpMethod.Get
            };
            var response = await HttpClient.SendAsync(httpRequestMessage);
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}
