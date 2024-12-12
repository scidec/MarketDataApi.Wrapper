using MarketDataApi.Wrapper.Models;

namespace MarketDataApi.Wrapper.Interfaces
{
	public interface IAPI
	{
		Task<List<Chain>> V1OptionChainAsync(string? underlying, DateTimeOffset? date = null, DateTimeOffset? expiration = null, DateTimeOffset? from = null, DateTimeOffset? to = null, int? month = null, int? year = null, bool? weekly = null, bool? monthly = null, bool? quarterly = null, int? dte = null, Side? side = null, Models.Range? range = null, float? strike = null, float? minOpenInterest = null, int? minVolume = null, float? maxBidAskSpread = null, float? maxBidAskSpreadPct = null, int? limit = null, int? offset = null, bool? headers = null, string? columns = null, bool? symbol_lookup = null, bool? quote = null, bool? human = null);
		Task<List<Expire>> V1OptionExpirationsAsync(string? underlying, float? strike = null, DateTimeOffset? date = null, int? limit = null, int? offset = null, bool? headers = null, string? columns = null, bool? symbol_lookup = null, bool? human = null);
		Task<List<OptionQuote>> V1OptionQuotesAsync(string? optionSymbol, DateTimeOffset? date = null, DateTimeOffset? from = null, DateTimeOffset? to = null, int? countback = null, int? limit = null, int? offset = null, bool? headers = null, string? columns = null, bool? human = null);
		Task<List<Strike>> V1OptionStrikesAsync(string? underlying, DateTimeOffset? date = null, DateTimeOffset? expiration = null, int? limit = null, int? offset = null, bool? headers = null, string? columns = null, bool? symbol_lookup = null, bool? human = null);
		Task<StockQuote> V1StockQuotesAsync(string? stockSymbol, int? limit = null, int? offset = null, bool? headers = null, string? columns = null, bool? symbol_lookup = null, bool? human = null);
		Task<List<StockEarning>> V1StockEarningsAsync(string? stockSymbol, DateTimeOffset? from = null, DateTimeOffset? to = null, int? countBack = null, DateTimeOffset? date = null, string? dateKey = null);
		Task<IndexQuote> V1IndexQuotesAsync(string? stockSymbol, int? limit = null, int? offset = null, bool? headers = null, string? columns = null, bool? symbol_lookup = null, bool? human = null);
	}
}