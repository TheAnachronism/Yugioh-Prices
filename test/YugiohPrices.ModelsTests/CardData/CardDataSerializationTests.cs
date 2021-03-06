using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Xunit;
using YugiohPrices.Models;
using YugiohPrices.Models.CardData;
using YugiohPrices.ModelsTests.Config;

namespace YugiohPrices.ModelsTests.CardData
{
    public class CardDataSerializationTests
    {
        [Fact]
        public void CardDataSerializationWithDemoResponse()
        {
            var jsonData = File.ReadAllText("./TestData/CardData/CardDataDemoResponse.json");
            var content =
                JsonSerializer.Deserialize<CardInformationResponse>(jsonData,
                    JsonSerializerTestOptions.JsonSerializerOptions);

            Assert.Equal(CardAttribute.Earth, content.Attribute);
        }

        [Fact]
        public void CardVersionSerializationWithDemoResponse()
        {
            var jsonData = File.ReadAllText("./TestData/CardData/CardVersionDemoResponse.json");
            var content =
                JsonSerializer.Deserialize<IEnumerable<CardVersionResponse>>(jsonData,
                    JsonSerializerTestOptions.JsonSerializerOptions);
            
            Assert.Equal(15, content.Count());
        }

        [Fact]
        public void CardSupportSerializationWithDemoResponse()
        {
            var jsonData = File.ReadAllText("./TestData/CardData/CardSupportDemoResponse.json");
            var content =
                JsonSerializer.Deserialize<IEnumerable<string>>(jsonData,
                    JsonSerializerTestOptions.JsonSerializerOptions);
            
            Assert.Equal(32, content.Count());
        }
    }
}