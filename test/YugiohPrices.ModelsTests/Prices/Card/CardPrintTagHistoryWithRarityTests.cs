using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Xunit;
using YugiohPrices.Models.Prices.Card;
using YugiohPrices.ModelsTests.Config;

namespace YugiohPrices.ModelsTests.Prices.Card
{
    public class CardPrintTagHistoryWithRarityTests
    {
        [Fact]
        public void CardPrintTagHistoryWithRarityWithDemoResponse()
        {
            var jsonContent = File.ReadAllText("./TestData/Prices/Card/CardPrintTagHistoryWithRarityDemoResponse.json");
            var content =
                JsonSerializer.Deserialize<IEnumerable<CardPrintTagHistoryEntry>>(jsonContent,
                    JsonSerializerTestOptions.JsonSerializerOptions);
            
            Assert.Equal(365, content.Count());
        }
    }
}