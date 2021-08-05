using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 1591

namespace YugiohPrices.Models
{
    /// <summary>
    /// Rarities of cards.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum CardRarity
    {
        Common,
        Rare,
        [EnumMember(Value = "Super Rare")]
        SuperRare,
        [EnumMember(Value = "Holofoil Rare")]
        HolofoilRare,
        [EnumMember(Value = "Ultra Rare")]
        UltraRare,
        [EnumMember(Value = "Ultimate Rare")]
        UltimateRare,
        [EnumMember(Value = "Secret Rare")]
        SecretRare,
        [EnumMember(Value = "Ultra Secret Rare")]
        UltraSecretRare,
        [EnumMember(Value = "Secret Ultra Rare")]
        SecretUltraRare,
        [EnumMember(Value = "Parallel Rare")]
        ParallelRare,
        [EnumMember(Value = "Starfoil Rare")]
        StarfoilRare,
        [EnumMember(Value = "Ghost Rare")]
        GhostRare,
        [EnumMember(Value = "Gold Ultra Rare")]
        GoldUltraRare
    }
}