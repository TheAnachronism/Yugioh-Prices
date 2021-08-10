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
        [EnumMember(Value = "Short Print")]
        ShortPrint,
        Rare,
        [EnumMember(Value = "Gold Rare")]
        GoldRare,
        [EnumMember(Value = "Ghost Rare")]
        GhostRare,
        [EnumMember(Value = "Ghost/Gold Rare")]
        GhostGoldRare,
        [EnumMember(Value = "Super Rare")]
        SuperRare,
        [EnumMember(Value = "Starfoil Rare")]
        StarfoilRare,
        [EnumMember(Value = "Starlight Rare")]
        StarlightRare,
        [EnumMember(Value = "Secret Rare")]
        SecretRare,
        [EnumMember(Value = "Prismatic Secret Rare")]
        PrismaticSecretRare,
        [EnumMember(Value = "Ultimate Rare")]
        UltimateRare,
        [EnumMember(Value = "Ultra Rare")]
        UltraRare,
        [EnumMember(Value = "10000 Secret Rare")]
        TenThousandSecretRare,
        [EnumMember(Value = "Collector's Rare")]
        CollectorsRare
    }
}