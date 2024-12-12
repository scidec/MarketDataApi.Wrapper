using MarketDataApi.Wrapper.Models;

namespace MarketDataApi.Wrapper.Interfaces
{
	internal interface IStockEarnings
	{
		public Task<List<StockEarning>> V1StockEarningsAsync(Format? format, string? stockSymbol, Dateformat? dateformat = null,
			DateTimeOffset? from = null, DateTimeOffset? to = null, int? countBack = null, DateTimeOffset? date = null, string? dateKey = null);
	}
}
