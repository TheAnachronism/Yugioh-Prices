using System.Text.Json.Serialization;
using YugiohPrices.Models.Converters;

namespace YugiohPrices.Models.Prices.Card
{
    /// <summary>
    /// Represents the price data object from the API for card tags.
    /// </summary>
    public class CardPrintTagPriceData
    {
        /// <summary>
        /// The name of the card
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The cards print tag
        /// </summary>
        [JsonPropertyName("print_tag")]
        public string PrintTag { get; set; }

        /// <summary>
        /// The cards rarity
        /// </summary>
        public CardRarity Rarity { get; set; }

        /// <summary>
        /// The cards price data info
        /// </summary>
        [JsonPropertyName("price_data")]
        [JsonConverter(typeof(CardNameResponsePriceDataConverter))]
        public CardNameResponsePriceData PriceData { get; set; }
    }
}