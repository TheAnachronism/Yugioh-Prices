using System.Text.Json.Serialization;
using YugiohPrices.Models.Converters;

namespace YugiohPrices.Models.Prices.Card
{
    /// <summary>
    /// Represents the API response from the "Check Price for Card Name" endpoint.
    /// </summary>
    public class CardNameResponse
    {
        /// <summary>
        /// The cards name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The cards print tag
        /// <example>LTGY-EN035</example>
        /// </summary>
        [JsonPropertyName("print_tag")]
        public string PrintTag { get; set; }

        /// <summary>
        /// The cards rarity
        /// </summary>
        public CardRarity Rarity { get; set; }
        
        /// <summary>
        /// This cards price data
        /// </summary>
        [JsonPropertyName("price_data")]
        [JsonConverter(typeof(CardNameResponsePriceDataConverter))]
        public CardNameResponsePriceData PriceData { get; set; }
    }
}