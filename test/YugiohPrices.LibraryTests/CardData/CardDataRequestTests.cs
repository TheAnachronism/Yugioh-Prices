using System.Threading.Tasks;
using Xunit;
using YugiohPrices.Library.Client;
using YugiohPrices.Models;

namespace YugiohPrices.LibraryTests.CardData
{
    public class CardDataRequestTests
    {
        private readonly IYugiohPricesClient _yugiohPricesClient;

        public CardDataRequestTests(IYugiohPricesClient yugiohPricesClient)
        {
            _yugiohPricesClient = yugiohPricesClient;
        }

        [Fact]
        public async Task GetCardDataReturnsValidJson()
        {
            var result = await _yugiohPricesClient.GetCardData("Raigeki");
            Assert.NotNull(result);
            Assert.Equal(CardType.Spell, result.CardType);
        }
    }
}