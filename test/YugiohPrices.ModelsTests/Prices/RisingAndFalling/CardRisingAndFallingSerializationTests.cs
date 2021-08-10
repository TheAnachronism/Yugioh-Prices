using System.IO;
using System.Linq;
using System.Text.Json;
using Xunit;
using YugiohPrices.Models.Prices.RisingAndFalling;
using YugiohPrices.ModelsTests.Config;

namespace YugiohPrices.ModelsTests.Prices.RisingAndFalling
{
    public class CardRisingAndFallingSerializationTests
    {
        [Fact]
        public void CardRisingAndFallingSerializationWithDemoResponse()
        {
            var jsonData = File.ReadAllText("./TestData/Prices/RisingAndFalling/RisingAndFallingDemoResponse.json");
            var content =
                JsonSerializer.Deserialize<CardRisingAndFallingResponse>(jsonData,
                    JsonSerializerTestOptions.JsonSerializerOptions);
            
            Assert.Equal(46, content.Rising.Count());
            Assert.Equal(50, content.Falling.Count());
        }
    }
}