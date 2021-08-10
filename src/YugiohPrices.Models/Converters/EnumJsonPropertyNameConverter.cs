using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace YugiohPrices.Models.Converters
{
    /// <inheritdoc />
    public class EnumJsonPropertyNameConverter<TEnum> : JsonConverter<TEnum> where TEnum : Enum
    {
        /// <inheritdoc />
        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var propertyValue = reader.GetString();
            if (string.IsNullOrEmpty(propertyValue))
                return default;
            
            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            try
            {
                return enumValues.Single(x =>
                {
                    var jsonName = GetJsonPropertyNameFromEnum(x);
                    return string.Equals(propertyValue, jsonName, StringComparison.InvariantCultureIgnoreCase);
                });
            }
            catch (InvalidOperationException)
            {
                throw new JsonException();
            }
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(GetJsonPropertyNameFromEnum(value));
        }

        private static string GetJsonPropertyNameFromEnum(TEnum type)
        {
            var enumMemberInfo = typeof(TEnum).GetMember(type.ToString());
            var enumValueMemberInfo = enumMemberInfo.FirstOrDefault(x => x.DeclaringType == typeof(TEnum));
            var valueAttributes = enumValueMemberInfo!.GetCustomAttributes<JsonPropertyNameAttribute>(false);

            return valueAttributes.FirstOrDefault()?.Name ?? type.ToString();
        }
    }
}