using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Xunit;
using YugiohPrices.Models.Prices.RisingAndFalling;
using YugiohPrices.ModelsTests.Config;

namespace YugiohPrices.ModelsTests.Prices.RisingAndFalling
{
    public class Top100CardsSerializationTests
    {
        [Fact]
        public void Top100CardsSerializationWithDemoResponse()
        {
            var jsonData =
                File.ReadAllText("./TestData/Prices/RisingAndFalling/Top100MostExpensiveCardDemoResponse.json");
            var content =
                JsonSerializer.Deserialize<IEnumerable<CardRisingAndFallingResponseEntry>>(jsonData,
                    JsonSerializerTestOptions.JsonSerializerOptions);
            
            Assert.Equal(100, content.Count());
        }
    }
}