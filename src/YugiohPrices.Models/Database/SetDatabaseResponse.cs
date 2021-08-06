using System.Text.Json.Serialization;
using YugiohPrices.Models.Converters;

namespace YugiohPrices.Models.Database
{
    /// <summary>
    /// Represents the list of sets in the yugioh prices database.
    /// </summary>
    [JsonConverter(typeof(SetDatabaseConverter))]
    public class SetDatabaseResponse
    {
        /// <summary>
        /// The different set names.
        /// </summary>
        public string[] Sets { get; init; }
    }
}