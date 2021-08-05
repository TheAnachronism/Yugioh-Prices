using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using YugiohPrices.Models.Prices.Card;

namespace YugiohPrices.Models.Converters
{
    /// <inheritdoc />
    public class CardNameResponsePriceDataConverter : JsonConverter<CardNameResponsePriceData>
    {
        /// <inheritdoc />
        public override CardNameResponsePriceData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            var data = doc.RootElement.GetProperty("data").GetProperty("prices");
            var result = JsonSerializer.Deserialize<CardNameResponsePriceData>(data.ToString()!, options);
            return result;
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, CardNameResponsePriceData value, JsonSerializerOptions options)
        {
            writer.WritePropertyName("status");
            writer.WriteStringValue("success");
            writer.WriteStartObject("data");
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}