﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Stranne.BooliLib.ApiModels;
using Stranne.BooliLib.Converters;
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
            Converters = new JsonConverter[]
            {
                new DateTimeOffsetJsonConverter()
            },
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public BaseService(string callerId, string key)
        {
            _callerId = callerId;
            _key = key;
        }

        public async Task<TResult> GetAsync<TResult>(string name, int booliId)
        {
            var pathUrl = $"{name}/{booliId}";
            var json = await GetAsync(pathUrl);

            var jsonObject = JObject.Parse(json);
            var result = jsonObject[name][0].ToObject<TResult>();

            return result;
        }

        public async Task<BooliResult<TResult, TSearchOptions>> GetAsync<TResult, TSearchOptions>(string name, TSearchOptions searchOptions)
            where TResult : IBooliId
        {
            var query = QueryHelper.GetQuery(searchOptions);
            var json = await GetAsync(name, query);

            var jsonObject = JObject.Parse(json);
            var results = jsonObject[name].ToObject<IEnumerable<TResult>>();
            var booliResult = jsonObject.ToObject<BooliResult<TResult, TSearchOptions>>();
            booliResult.Result = results;

            return booliResult;
        }

        private async Task<string> GetAsync(string relativeUrl, IDictionary<string, string> query = null)
        {
            if (query == null)
            {
                query = new Dictionary<string, string>(4);
            }
            relativeUrl = $"{relativeUrl}?{BuildQuery(query)}";

            var json = await NetworkService.DownloadStringAsync(relativeUrl);
            return json;
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
