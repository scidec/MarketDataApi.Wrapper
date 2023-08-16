namespace Api.Testing
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;
    using System.Threading.Tasks;

    [TestClass()]
    public class Options
    {
        private readonly MarketDataApi.API _api;
        private readonly MarketDataApi.API _apiProxy;
        private readonly MarketDataApi.API _apiSource;

        public Options()
        {
            string apiKey = null;
            try
            {
                apiKey = File.ReadAllText(@"c:\temp\MarketDataApiKey.txt");
            }
            catch
            {
                throw;
            }
            finally
            {
                apiKey ??= "demo";
            }
            System.Net.WebProxy proxy = new("localhost:80");
            _api = new MarketDataApi.API(apiKey);
            _apiProxy = new MarketDataApi.API(apiKey, proxy);
            _apiSource = new MarketDataApi.API(apiKey, null, "MarketDataApi.Tester");
        }

        [TestMethod()]
        public async Task GetOptionQuotes()
        {
            var result = await _api.V1OptionQuotesAsync("AAPL250117C00150000");
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async Task GetOptionHistoricalQuotes()
        {
            var result = await _api.V1OptionQuotesAsync("AAPL250117C00150000", null,
                new DateTimeOffset(new DateTime(2023, 1, 20)),
                new DateTimeOffset(new DateTime(2023, 5, 1)));
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async Task GetOptionChains()
        {
            var result = await _api.V1OptionChainAsync("AAPL");
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async Task GetOptionExpirations()
        {
            var result = await _api.V1OptionExpirationsAsync("AAPL");
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async Task GetOptionStrikes()
        {
            var result = await _api.V1OptionStrikesAsync("AAPL");
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async Task DoOptionSymbolLookup()
        {
            var result = await _api.V1OptionLookupAsync("AAPL250117C00150000");
            Assert.IsNotNull(result);
        }
    }
}