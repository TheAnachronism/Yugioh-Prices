using System.Text.Json.Serialization;

#pragma warning disable 1591
namespace YugiohPrices.Models
{
    /// <summary>
    /// Represents the family a monster can be.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum CardAttribute
    {
        Dark,
        Divine,
        Earth,
        Fire,
        Light,
        Water,
        Wind
    }
}