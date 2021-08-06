using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YugiohPrices.Models.Prices.Set
{
    /// <summary>
    /// Represents a card from a set price response.
    /// </summary>
    public class SetCardEntry
    {
        /// <summary>
        /// The cards name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price entries for this card.
        /// </summary>
        public IEnumerable<SetCardNumberPriceEntry> Numbers { get; set; }

        /// <summary>
        /// This cards type
        /// </summary>
        public CardType CardType { get; set; }

        /// <summary>
        /// This cards property
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// This cards attribute
        /// </summary>
        [JsonPropertyName("family")]
        public CardAttribute? Attribute { get; set; }

        /// <summary>
        /// This cards types.
        /// </summary>
        public string Type { get; set; }
    }
}