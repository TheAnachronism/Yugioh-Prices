using System.IO;
using System.Text.Json;
using Xunit;
using YugiohPrices.Models.Prices.Set;
using YugiohPrices.ModelsTests.Config;

namespace YugiohPrices.ModelsTests.Prices.Set
{
    public class SetAllCardPricesSerializationTests
    {
        [Fact]
        public void SetAllCardPricesSerializationWithDemoResponse()
        {
            var jsonData = File.ReadAllText("./TestData/Prices/Set/SetAllCardPricesDemoResponse.json");
            var content =
                JsonSerializer.Deserialize<SetAllCardPricesResponse>(jsonData,
                    JsonSerializerTestOptions.JsonSerializerOptions);

            Assert.NotNull(content.TCGBoosterValues);
        }
    }
}