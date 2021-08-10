using System;
using System.Text.Json.Serialization;

namespace YugiohPrices.Models.CardData
{
    /// <summary>
    /// Represents the API response for a single card without price information.
    /// </summary>
    public class CardInformationResponse
    {
        /// <summary>
        /// The cards name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The cars effect text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The cards type
        /// </summary>
        [JsonPropertyName("card_type")]
        public CardType CardType { get; set; }

        /// <summary>
        /// The cards monster type if it is one
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The cards attribute
        /// </summary>
        [JsonPropertyName("Family")]
        public CardAttribute Attribute { get; set; }

        /// <summary>
        /// The monsters attack points.
        /// </summary>
        [JsonPropertyName("Atk")]
        public int Attack { get; set; }

        /// <summary>
        /// The monsters defense points.
        /// </summary>
        [JsonPropertyName("def")]
        public int Defense { get; set; }

        /// <summary>
        /// The monsters level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// The cards property
        /// </summary>
        public string Property { get; set; }
    }
}