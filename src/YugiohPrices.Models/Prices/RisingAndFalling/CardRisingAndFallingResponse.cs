using System.Collections.Generic;

namespace YugiohPrices.Models.Prices.RisingAndFalling
{
    /// <summary>
    /// Represents the API response from the rising and falling endpoint.
    /// </summary>
    public class CardRisingAndFallingResponse
    {
        /// <summary>
        /// The cards that are currently rising in prices.
        /// </summary>
        public IEnumerable<CardRisingAndFallingResponseEntry> Rising { get; set; }
        /// <summary>
        /// The cars that are currently falling in prices.
        /// </summary>
        public IEnumerable<CardRisingAndFallingResponseEntry> Falling { get; set; }
    }
}