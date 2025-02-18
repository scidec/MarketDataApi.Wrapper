﻿namespace Api.Testing
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.IO;
	using System.Threading.Tasks;

	[TestClass()]
	public class Stocks
	{
		private readonly MarketDataApi.API _api;
		private readonly MarketDataApi.API _apiProxy;
		private readonly MarketDataApi.API _apiSource;

		public Stocks()
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
		public async Task GetStockQuotes()
		{
			var result = await _api.V1StockQuotesAsync("AAPL");
			Assert.IsNotNull(result);
		}

		[TestMethod()]
		public async Task GetStockEarnings()
		{
			var result = await _api.V1StockEarningsAsync("AAPL");
			Assert.IsNotNull(result);
		}

		[TestMethod()]
		public async Task GetStockCandles()
		{
			var result = await _api.V1StockCandlesAsync("AAPL", "D", new DateTimeOffset(new DateTime(2020, 01, 01)), new DateTimeOffset(new DateTime(2020, 12, 31)));
			Assert.IsNotNull(result);
		}
	}
}