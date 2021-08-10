using System.IO;
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
    }
}