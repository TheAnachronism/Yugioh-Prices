using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using YugiohPrices.Models;
using YugiohPrices.Models.CardData;
using YugiohPrices.Models.Database;
using YugiohPrices.Models.Prices.Card;
using YugiohPrices.Models.Prices.RisingAndFalling;
using YugiohPrices.Models.Prices.Set;

namespace YugiohPrices.Library.Client
{
    public interface IYugiohPricesClient
    {
        /// <summary>
        /// Gets the prices for the card with the given name.
        /// </summary>
        /// <param name="name">The name of the card.</param>
        /// <returns>A list of price card information with the given card name.</returns>
        Task<IEnumerable<CardNameResponse>> GetCardPricesForName(string name);

        /// <summary>
        /// Gets the card prices for the specific card edition with the given print tag. 
        /// </summary>
        /// <param name="printTag">The print tag of the card</param>
        /// <returns>The price information of the card with the given print tag.</returns>
        Task<CardPrintTagResponse> GetCardPricesForPrintTag(string printTag);

        /// <summary>
        /// Gets the price history of a specific card with the given rarity.
        /// </summary>
        /// <param name="printTag">The print tag of the card.</param>
        /// <param name="rarity">The rarity of the card.</param>
        /// <returns>The entire price history of the card for the past year.</returns>
        Task<IEnumerable<CardPrintTagHistoryEntry>> GetCardPriceHistoryWithRarity(string printTag, CardRarity rarity);

        /// <summary>
        /// Gets the price information for a specific set.
        /// </summary>
        /// <param name="setName">The name of the set.</param>
        /// <returns>The price information of the set with all its cards.</returns>
        Task<SetAllCardPricesResponse> GetSetPriceWithAllCards(string setName);

        /// <summary>
        /// Gets all the current sets in the yugioh prices database.
        /// </summary>
        /// <returns>A list of set names.</returns>
        Task<SetDatabaseResponse> GetSetNames();

        /// <summary>
        /// Retrieve rising and falling cards list.
        /// </summary>
        Task<CardRisingAndFallingResponse> GetCurrentRisingAndFallingCards();

        /// <summary>
        /// Gets the top 100 most expensive cards with the given rarity from the API.
        /// </summary>
        Task<IEnumerable<CardRisingAndFallingResponseEntry>> GetTop100Cards(CardRarity rarity);

        /// <summary>
        /// Gets the card information of the card with the given name.
        /// </summary>
        Task<CardInformationResponse> GetCardData(string cardName);

        /// <summary>
        /// Gets the different versions of the card with the given name.
        /// </summary>
        Task<IEnumerable<CardVersionResponse>> GetCardVersions(string cardName);

        /// <summary>
        /// Gets support card names for a specific card.
        /// </summary>
        Task<IEnumerable<string>> GetCardSupport(string cardName);

        /// <summary>
        /// Gets the image of the card with the given name.
        /// </summary>
        Task<Image> GetCardImage(string cardName);

        /// <summary>
        /// Gets the image of the set with the given name.
        /// </summary>
        /// <param name="setName"></param>
        /// <returns></returns>
        Task<Image> GetCardSetImage(string setName);
    }
}