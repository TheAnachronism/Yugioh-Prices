using System.Text.Json.Serialization;
using YugiohPrices.Models.Converters;
using YugiohPrices.Models.Prices.Card;

namespace YugiohPrices.Models.Prices.Set
{
    /// <summary>
    /// Represents a single card entry for the set endpoint response.
    /// </summary>
    public class SetCardNumberPriceEntry
    {
        /// <summary>
        /// This cards name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This cards print tag.
        /// </summary>
        [JsonPropertyName("print_tag")]
        public string PrintTag { get; set; }

        /// <summary>
        /// The rarity of this card.
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