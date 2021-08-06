using System.Collections.Generic;
using System.Threading.Tasks;
using YugiohPrices.Models;
using YugiohPrices.Models.Prices.Card;

namespace YugiohPrices.Library.Client
{
    public interface IYugiohPricesClient
    {
        Task<IEnumerable<CardNameResponse>> GetCardPricesForName(string name);
        Task<CardPrintTagResponse> GetCardPricesForPrintTag(string printTag);
        Task<IEnumerable<CardPrintTagHistoryEntry>> GetCardPriceHistoryWithRarity(string printTag, CardRarity rarity);
    }
}