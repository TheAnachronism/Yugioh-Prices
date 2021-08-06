using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using YugiohPrices.Models.Database;

namespace YugiohPrices.Models.Converters
{
    /// <inheritdoc />
    public class SetDatabaseConverter : JsonConverter<SetDatabaseResponse>
    {
        /// <inheritdoc />
        public override SetDatabaseResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var sets = new List<string>();
            while (reader.Read())
            {
                if(reader.TokenType is JsonTokenType.String)
                    sets.Add(reader.GetString());
            }

            return new SetDatabaseResponse { Sets = sets.ToArray() };
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, SetDatabaseResponse value, JsonSerializerOptions options)
        {
            foreach (var set in value.Sets)
            {
                writer.WriteStringValue(set);
            }
        }
    }
}