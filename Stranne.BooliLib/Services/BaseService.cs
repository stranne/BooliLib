using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Stranne.BooliLib.Helpers;

namespace Stranne.BooliLib.Services
{
    internal class BaseService : IDisposable
    {
        private readonly string _callerId;
        private readonly string _key;

        internal NetworkService NetworkService { get; set; } = new NetworkService();

        internal readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public BaseService(string callerId, string key)
        {
            _callerId = callerId;
            _key = key;
        }

        public async Task<T> GetAsync<T>(string featureUrl, int booliId)
        {
            var pathUrl = $"{featureUrl}/{booliId}";
            return await GetAsync<T>(pathUrl);
        }

        public async Task<T> GetAsync<T>(string relativeUrl, IDictionary<string, string> query = null)
        {
            if (query == null)
            {
                query = new Dictionary<string, string>(4);
            }
            relativeUrl = $"{relativeUrl}?{BuildQuery(query)}";

            var json = await NetworkService.DownloadStringAsync(relativeUrl);
            var data = JsonConvert.DeserializeObject<T>(json);
            return data;
        }

        internal string BuildQuery(IDictionary<string, string> queries)
        {
            var authenticationQuery = AuthenticationHelper.GetAuthenticationQuery(_callerId, _key);
            authenticationQuery.ToList().ForEach(queries.Add);

            var queryString = string.Join("&", queries.Select(query => $"{query.Key}={query.Value}"));
            return queryString;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            NetworkService.Dispose();
        }
    }
}
