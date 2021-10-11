using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Options;
using YugiohPrices.Library.Services;
using YugiohPrices.Models;
using YugiohPrices.Models.CardData;
using YugiohPrices.Models.Database;
using YugiohPrices.Models.Prices.Card;
using YugiohPrices.Models.Prices.RisingAndFalling;
using YugiohPrices.Models.Prices.Set;

namespace YugiohPrices.Library.Client
{
    internal class YugiohPricesClient : IYugiohPricesClient
    {
        private readonly IYugiohPricesHttpClientService _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public YugiohPricesClient(IYugiohPricesHttpClientService httpClient,
            IOptions<YugiohPricesClientJsonSerializerOptions> options)
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

        public async Task<IEnumerable<CardPrintTagHistoryEntry>> GetCardPriceHistoryWithRarity(string printTag,
            CardRarity rarity)
        {
            var baseUrl = $"price_history/{printTag}";
            var requestUrl = BuildRequestUrl(baseUrl, new NameValueCollection
            {
                {
                    "rarity", Enum.GetName(rarity)
                }
            });
            var content = await _httpClient.GetAsync(requestUrl);

            return JsonSerializer.Deserialize<IEnumerable<CardPrintTagHistoryEntry>>(content, _jsonOptions);
        }

        public async Task<SetAllCardPricesResponse> GetSetPriceWithAllCards(string setName)
        {
            var baseUrl = $"set_data/{setName.Replace(" ", "+")}";
            var requestUrl = BuildRequestUrl(baseUrl);
            var content = await _httpClient.GetAsync(requestUrl);

            return JsonSerializer.Deserialize<SetAllCardPricesResponse>(content, _jsonOptions);
        }

        public async Task<SetDatabaseResponse> GetSetNames()
        {
            const string baseUrl = "card_sets";
            var requestUrl = BuildRequestUrl(baseUrl);
            var content = await _httpClient.GetAsync(requestUrl);

            return JsonSerializer.Deserialize<SetDatabaseResponse>(content, _jsonOptions);
        }

        public async Task<CardRisingAndFallingResponse> GetCurrentRisingAndFallingCards()
        {
            const string baseUrl = "rising_and_falling";
            var requestUrl = BuildRequestUrl(baseUrl);
            var content = await _httpClient.GetAsync(requestUrl);

            return JsonSerializer.Deserialize<CardRisingAndFallingResponse>(content, _jsonOptions);
        }

        public async Task<IEnumerable<CardRisingAndFallingResponseEntry>> GetTop100Cards(CardRarity rarity)
        {
            const string baseUrl = "top_100_cards";
            var requestUrl = BuildRequestUrl(baseUrl,
                new NameValueCollection { { "rarity", GetEnumMemberAttrValue(rarity) } });
            var content = await _httpClient.GetAsync(requestUrl);

            return JsonSerializer.Deserialize<IEnumerable<CardRisingAndFallingResponseEntry>>(content, _jsonOptions);
        }

        public async Task<CardInformationResponse> GetCardData(string cardName)
        {
            var baseUrl = $"card_data/{HttpUtility.UrlEncode(cardName)}";
            var requestUrl = BuildRequestUrl(baseUrl);
            var content = await _httpClient.GetAsync(requestUrl);

            return JsonSerializer.Deserialize<CardInformationResponse>(content, _jsonOptions);
        }

        public async Task<IEnumerable<CardVersionResponse>> GetCardVersions(string cardName)
        {
            var baseUrl = $"card_versions/{HttpUtility.UrlEncode(cardName)}";
            var requestUrl = BuildRequestUrl(baseUrl);
            var content = await _httpClient.GetAsync(requestUrl);

            return JsonSerializer.Deserialize<IEnumerable<CardVersionResponse>>(content, _jsonOptions);
        }

        public async Task<IEnumerable<string>> GetCardSupport(string cardName)
        {
            var baseUrl = $"card_support/{HttpUtility.UrlEncode(cardName)}";
            var requestUrl = BuildRequestUrl(baseUrl);
            var content = await _httpClient.GetAsync(requestUrl);

            return JsonSerializer.Deserialize<IEnumerable<string>>(content, _jsonOptions);
        }

        public async Task<Image> GetCardImage(string cardName)
        {
            var baseUrl = $"card_image/{HttpUtility.UrlEncode(cardName)}";
            var requestUrl = BuildRequestUrl(baseUrl);
            return await _httpClient.GetImageAsync(requestUrl);
        }

        public async Task<Image> GetCardSetImage(string setName)
        {
            var baseUrl = $"set_image/{HttpUtility.UrlEncode(setName)}";
            var requestUrl = BuildRequestUrl(baseUrl);
            return await _httpClient.GetImageAsync(requestUrl);
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

        private string GetEnumMemberAttrValue<TEnum>(TEnum enumVal) where TEnum : Enum
        {
            var memInfo = typeof(TEnum).GetMember(enumVal.ToString());
            var attr = memInfo[0].GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
            return attr?.Value;
        }
    }
}