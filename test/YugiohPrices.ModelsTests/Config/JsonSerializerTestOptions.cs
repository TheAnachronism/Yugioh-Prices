using System.Text.Json;
using System.Text.Json.Serialization;

namespace YugiohPrices.ModelsTests.Config
{
    public static class JsonSerializerTestOptions
    {
        public static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumMemberConverter() }};
    }
}