using System;
using System.Text.Json.Serialization;
using YugiohPrices.Models.Converters;

namespace YugiohPrices.Models.Prices.Card
{
    /// <summary>
    /// Represents the API response for the check price for card with rarity endpoint.
    /// </summary>
    public class CardPrintTagHistoryEntry
    {
        /// <summary>
        /// The average price of the card at the time.
        /// </summary>
        [JsonPropertyName("price_average")]
        public double PriceAverage { get; set; }

        /// <summary>
        /// The lowest price of the card at the time.
        /// </summary>
        [JsonPropertyName("price_low")]
        public double PriceLow { get; set; }

        /// <summary>
        /// The highest price for the card at the time.
        /// </summary>
        [JsonPropertyName("price_high")]
        public double PriceHigh { get; set; }

        /// <summary>
        /// The price shift to last entry.
        /// </summary>
        [JsonPropertyName("price_shift")]
        public double PriceShift { get; set; }

        /// <summary>
        /// The time this entry was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(StringToDateTimeConverter))]
        public DateTime CreatedAt { get; set; }
    }
}