using System.Text.Json.Serialization;

#pragma warning disable 1591
namespace YugiohPrices.Models
{
    /// <summary>
    /// The different types a card can be.
    /// </summary>
    public enum CardType
    {
        Monster,
        Spell,
        Trap
    }
}