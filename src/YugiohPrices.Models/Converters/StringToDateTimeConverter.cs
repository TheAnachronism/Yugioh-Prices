using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace YugiohPrices.Models.Converters
{
    /// <inheritdoc />
    public class StringToDateTimeConverter : JsonConverter<DateTime>
    {
        /// <inheritdoc />
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (DateTime.TryParse(value, out var result))
                return result;

            throw new JsonException();
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd hh:mm:ss"));
        }
    }
}