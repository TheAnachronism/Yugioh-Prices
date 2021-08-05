using System.Text.Json.Serialization;

namespace YugiohPrices.Models.Prices.Card
{
    /// <summary>
    /// Represents the response object from check price for cards print tag endpoint.
    /// </summary>
    public class CardPrintTagResponse
    {
        /// <summary>
        /// The cards name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The cards type.
        /// </summary>
        [JsonPropertyName("card_type")]
        public CardType CardType { get; set; }

        /// <summary>
        /// The cards family.
        /// </summary>
        public CardAttribute? Family { get; set; }

        /// <summary>
        /// The cars monster type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The cars price data.
        /// </summary>
        [JsonPropertyName("price_data")]
        public CardPrintTagPriceData PriceData { get; set; }
    }
}