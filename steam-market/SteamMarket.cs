using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

using steam_market_model;

namespace steam_market
{
    public class SteamMarket : ISteamMarket
    {
        private HttpClient _httpClient;
        private const string _itemPriceBase = "https://steamcommunity.com/market/priceoverview?";

        public SteamMarket()
        {
            _httpClient = new HttpClient();
        }

        public SteamMarket(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Gets a Steam Market item.
        /// </summary>
        /// <param name="appid">The Steam Game AppID</param>
        /// <param name="marketHashName">Market Hash Name of the Steam Market item</param>
        /// <param name="currency">Steam Market currency code</param>
        /// <returns>A Steam Market item model.</returns>
        public async Task<Item> GetItemAsync(int appid, string marketHashName, Currency.Code currency = Currency.Code.DEFAULT)
        {
            var request = GetItemMessage(appid, marketHashName, currency);

            var response = await _httpClient.SendAsync(request);

            return JsonConvert.DeserializeObject<Item>(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Creates the HttpRequestMessage for getting a Steam Market item.
        /// </summary>
        /// <param name="appid">The Steam Game AppID</param>
        /// <param name="marketHashName">Market Hash Name of the Steam Market item</param>
        /// <param name="currency">Steam Market currency code</param>
        /// <returns>A HttpRequestMessage.</returns>
        private HttpRequestMessage GetItemMessage(int appid, string marketHashName, Currency.Code currency = Currency.Code.DEFAULT)
        {
            var queryParams = new Dictionary<string, string>()
            {
                { "currency", currency.ToString() },
                { "appid", appid.ToString() },
                { "market_hash_name", marketHashName }
            };

            // TODO: The first query param will still have the &. Find a way to remove it.
            var uri = QueryHelpers.AddQueryString(_itemPriceBase, queryParams);

            HttpRequestMessage message = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri)
            };

            return message; 
        }
    }
}
