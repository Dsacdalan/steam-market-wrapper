using System.Net.Http;
using System.Threading.Tasks;

using NUnit.Framework;

using steam_market;
using steam_market_model;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private HttpClient _httpClient;
        private SteamMarket _steamMarket;

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
            _steamMarket = new SteamMarket(_httpClient);
        }

        /// <summary>
        /// Gets the market data for an item.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetArtifactAxeAsync()
        {
            var data = await _steamMarket.GetItemAsync(583950, "110315", Currency.Code.DEFAULT);

            Assert.IsTrue(data.Success);
        }

    }
}