using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Options;
using YugiohPrices.Library.Services;
using YugiohPrices.Models;
using YugiohPrices.Models.Prices.Card;

namespace YugiohPrices.Library.Client
{
    internal class YugiohPricesClient : IYugiohPricesClient
    {
        private readonly IHttpClientService _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public YugiohPricesClient(IHttpClientService httpClient, IOptions<YugiohPricesClientJsonSerializerOptions> options)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _jsonOptions = options?.Value?.JsonSerializerOptions ?? throw new ArgumentNullException(
                nameof(options));
        }

        public async Task<IEnumerable<CardNameResponse>> GetCardPricesForName(string name)
        {
            var baseUrl = $"get_card_prices/{name}";
            var requestUrl = BuildRequestUrl(baseUrl);
            var content = await _httpClient.GetAsync(requestUrl);

            return JsonSerializer.Deserialize<IEnumerable<CardNameResponse>>(content, _jsonOptions);
        }

        public async Task<CardPrintTagResponse> GetCardPricesForPrintTag(string printTag)
        {
            var baseUrl = $"price_for_print_tag/{printTag}";
            var requestUrl = BuildRequestUrl(baseUrl);
            var content = await _httpClient.GetAsync(requestUrl);

            return JsonSerializer.Deserialize<CardPrintTagResponse>(content, _jsonOptions);
        }

        public async Task<IEnumerable<CardPrintTagHistoryEntry>> GetCardPriceHistoryWithRarity(string printTag, CardRarity rarity)
        {
            var baseUrl = $"price_history/{printTag}";
            var requestUrl = BuildRequestUrl(baseUrl, new NameValueCollection
            {
                {
                    "rarity", Enum.GetName(rarity)
                }
            });
            var content = await _httpClient.GetAsync(requestUrl);

            return JsonSerializer.Deserialize<IEnumerable<CardPrintTagHistoryEntry>>(content);
        }

        private static string BuildRequestUrl(string urlSlug, NameValueCollection queryParameters)
        {
            return BuildRequestUrl(urlSlug + ToQueryString(queryParameters));
        }

        private static string BuildRequestUrl(string urlSlug)
        {
            const string baseUrl = "https://yugiohprices.com/api/{0}";
            return string.Format(baseUrl, urlSlug);
        }

        private static string ToQueryString(NameValueCollection query)
        {
            var array = (
                    from key in query.AllKeys
                    from value in query.GetValues(key)
                    select $"{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(value)}")
                .ToArray();

            return "?" + string.Join("&", array);
        }
    }
}