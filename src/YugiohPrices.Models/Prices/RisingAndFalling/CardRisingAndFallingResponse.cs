using System.Collections.Generic;

namespace YugiohPrices.Models.Prices.RisingAndFalling
{
    /// <summary>
    /// Represents the API response from the rising and falling endpoint.
    /// </summary>
    public class CardRisingAndFallingResponse
    {
        public IEnumerable<CardRisingAndFallingResponseEntry> Rising { get; set; }
        public IEnumerable<CardRisingAndFallingResponseEntry> Falling { get; set; }
    }
}