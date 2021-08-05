using System.IO;
using System.Text.Json;
using Xunit;
using YugiohPrices.Models.Prices.Card;
using YugiohPrices.ModelsTests.Config;

namespace YugiohPrices.ModelsTests.Prices.Card
{
    public class CardPrintTagSerializationTests
    {
        [Fact]
        public void CardPrintTagSerializationWithDemoResponse()
        {
            var jsonData = File.ReadAllText("./TestData/Prices/Card/CardPrintTagDemoResponse.json");
            var content =
                JsonSerializer.Deserialize<CardPrintTagResponse>(jsonData,
                    JsonSerializerTestOptions.JsonSerializerOptions);
            
            Assert.NotNull(content.PriceData);
        }
    }
}