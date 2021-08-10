using System.Text.Json.Serialization;

namespace YugiohPrices.Models.Prices.RisingAndFalling
{
    /// <summary>
    /// Represents a single response entry from the rising and falling endpoint.
    /// </summary>
    public class CardRisingAndFallingResponseEntry
    {
        /// <summary>
        /// The cards name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The cards current price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// The cards price shift.
        /// </summary>
        [JsonPropertyName("price_shift")]
        public double PriceShift { get; set; }

        /// <summary>
        /// The cards number
        /// </summary>
        [JsonPropertyName("card_number")]
        public string CardNumber { get; set; }

        /// <summary>
        /// The set this card comes from
        /// </summary>
        [JsonPropertyName("card_set")]
        public string CardSet { get; set; }

        /// <summary>
        /// The cards rarity.
        /// </summary>
        public CardRarity Rarity { get; set; }
    }
}