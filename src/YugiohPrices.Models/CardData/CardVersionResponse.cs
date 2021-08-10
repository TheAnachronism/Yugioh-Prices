namespace YugiohPrices.Models.CardData
{
    /// <summary>
    /// Represents a single response object for the card version endpoint.
    /// </summary>
    public class CardVersionResponse
    {
        /// <summary>
        /// The sets name this card version was released in.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This card versions print tag. 
        /// </summary>
        public string PrintTag { get; set; }

        /// <summary>
        /// The rarity of this card version.
        /// </summary>
        public CardRarity Rarity { get; set; }
    }
}