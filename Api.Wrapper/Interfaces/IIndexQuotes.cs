using MarketDataApi.Wrapper.Models;

namespace MarketDataApi.Wrapper.Interfaces
{
	internal interface IIndexQuotes
	{
		public Task<IndexQuote> V1IndexQuotesAsync(Format? format, string? stockSymbol, Dateformat? dateformat = null,
			int? limit = null, int? offset = null, bool? headers = null, string? columns = null, bool? symbol_lookup = null, bool? human = null);
	}
}
