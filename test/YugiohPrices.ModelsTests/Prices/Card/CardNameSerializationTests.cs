using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Xunit;
using YugiohPrices.Models.Prices.Card;
using YugiohPrices.ModelsTests.Config;

namespace YugiohPrices.ModelsTests.Prices.Card
{
    public class CardNameSerializationTests
    {
        [Fact]
        public void CardNameSerializationWithDemoResponse()
        {
            var jsonData = File.ReadAllText("./TestData/Prices/Card/CardNameDemoResponse.json");
            var content = JsonSerializer.Deserialize<IEnumerable<CardNameResponse>>(jsonData, JsonSerializerTestOptions.JsonSerializerOptions);
            
            Assert.Equal(15, content.Count());
        }
    }
}