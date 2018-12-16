using System.Threading.Tasks;

using steam_market_model;

namespace steam_market
{
    public interface ISteamMarket
    {
        /// <summary>
        /// Gets a Steam Market item.
        /// </summary>
        Task<Item> GetItemAsync(int appid, string marketHashName, Currency.Code currency);
    }
}
