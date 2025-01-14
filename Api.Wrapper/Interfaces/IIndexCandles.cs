using MarketDataApi.Wrapper.Models;

namespace MarketDataApi.Wrapper.Interfaces
{
	internal interface IIndexCandles
	{
		public Task<List<IndexCandle>> V1IndexCandlesAsync(Format? format, string? stockSymbol, string? resolution,
			Dateformat? dateformat = null, DateTimeOffset? from = null, DateTimeOffset? to = null,
			int? countBack = null, bool? extended = null, bool? adjustsplits = null);
	}
}
