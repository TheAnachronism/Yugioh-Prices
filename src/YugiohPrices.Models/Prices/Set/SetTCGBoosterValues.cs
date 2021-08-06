namespace YugiohPrices.Models.Prices.Set
{
    /// <summary>
    /// The booster values for TCG of a set.
    /// </summary>
    public struct SetTCGBoosterValues
    {
        /// <summary>
        /// The highest price for one booster.
        /// </summary>
        public double High { get; set; }

        /// <summary>
        /// The lowest price for one booster.
        /// </summary>
        public double Low { get; set; }

        /// <summary>
        /// The average price for one booster.
        /// </summary>
        public double Average { get; set; }
    }
}