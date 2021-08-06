using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YugiohPrices.Models.Prices.Set
{
    /// <summary>
    /// Represents the API response for the set all cards endpoint.
    /// </summary>
    public class SetAllCardPricesResponse
    {
        /// <summary>
        /// The amount of rarities in this set.
        /// </summary>
        public SetRarities Rarities { get; set; }

        /// <summary>
        /// The average price for the entire set.
        /// </summary>
        public double Average { get; set; }

        /// <summary>
        /// The lowest price for the entire set.
        /// </summary>
        public double Lowest { get; set; }

        /// <summary>
        /// The highest price for the entire set.
        /// </summary>
        public double Highest { get; set; }

        /// <summary>
        /// The booster price information
        /// </summary>
        [JsonPropertyName("tcg_booster_values")]
        public SetTCGBoosterValues TCGBoosterValues { get; set; }

        /// <summary>
        /// The cards in this set.
        /// </summary>
        public IEnumerable<SetCardEntry> Cards { get; set; }
    }
}