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
        [EnumMember(Value = "Ultra Rare")]
        UltraRare,
        [EnumMember(Value = "Super Rare")]
        SuperRare,
        Rare,
        [EnumMember(Value = "Starfoil Rare")]
        StarfoilRare,
        [EnumMember(Value = "Prismatic Secret Rare")]
        PrismaticSecretRare,
        [EnumMember(Value = "Gold Rare")]
        GoldRare,
        [EnumMember(Value = "Secret Rare")]
        SecretRare,
        [EnumMember(Value = "Ultimate Rare")]
        UltimateRare
    }
}