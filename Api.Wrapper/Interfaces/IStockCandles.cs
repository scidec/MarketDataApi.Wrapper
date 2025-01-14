using MarketDataApi.Wrapper.Models;

namespace MarketDataApi.Wrapper.Interfaces
{
	internal interface IStockCandles
	{
		public Task<List<StockCandle>> V1StockCandlesAsync(Format? format, string? stockSymbol, string? resolution,
			Dateformat? dateformat = null, DateTimeOffset? from = null, DateTimeOffset? to = null,
			int? countBack = null, bool? extended = null, bool? adjustsplits = null);
	}
}
