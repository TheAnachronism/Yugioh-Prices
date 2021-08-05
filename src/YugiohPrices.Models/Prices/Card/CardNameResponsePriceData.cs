using System;
using System.Text.Json.Serialization;
using YugiohPrices.Models.Converters;

namespace YugiohPrices.Models.Prices.Card
{
    /// <summary>
    /// Represents the price data object from the card name endpoint.
    /// </summary>
    public class CardNameResponsePriceData
    {
        /// <summary>
        /// The current highest price for the card.
        /// </summary>
        public double High { get; set; }

        /// <summary>
        /// The current lowest price for the card. 
        /// </summary>
        public double Low { get; set; }

        /// <summary>
        /// The average price for the card.
        /// </summary>
        public double Average { get; set; }

        /// <summary>
        /// The last time this price data was updated.
        /// </summary>
        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(StringToDateTimeConverter))]
        public DateTime UpdatedAt { get; set; }
    }
}