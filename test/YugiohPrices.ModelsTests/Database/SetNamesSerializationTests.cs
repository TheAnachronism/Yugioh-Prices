using System.IO;
using System.Linq;
using System.Text.Json;
using Xunit;
using YugiohPrices.Models.Database;
using YugiohPrices.ModelsTests.Config;

namespace YugiohPrices.ModelsTests.Database
{
    public class SetNamesSerializationTests
    {
        [Fact]
        public void SetNamesSerializationWithDemoResponse()
        {
            var jsonContent = File.ReadAllText("./TestData/Database/SetNamesDemoResponse.json");
            var content =
                JsonSerializer.Deserialize<SetDatabaseResponse>(jsonContent,
                    JsonSerializerTestOptions.JsonSerializerOptions);
            
            Assert.Equal(15, content.Sets.Count());
        }
    }
}