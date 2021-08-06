using System.Text.Json.Serialization;

#pragma warning disable 1591

namespace YugiohPrices.Models.Prices.Set
{
    /// <summary>
    /// The amount of rarities a set can have.
    /// </summary>
    public struct SetRarities
    {
        public int Rare { get; set; }
        public int Common { get; set; }
        [JsonPropertyName("Ultra Rare")]
        public int UltraRare { get; set; }
        [JsonPropertyName("Ultimate Rare")]
        public int UltimateRare { get; set; }
        [JsonPropertyName("Super Rare")]
        public int SuperRare { get; set; }
        [JsonPropertyName("Secret Rare")]
        public int SecretRare { get; set; }
        [JsonPropertyName("Short Print")]
        public int ShortPrint { get; set; }
        [JsonPropertyName("Ghost Rare")]
        public int GhostRare { get; set; }
    }
}