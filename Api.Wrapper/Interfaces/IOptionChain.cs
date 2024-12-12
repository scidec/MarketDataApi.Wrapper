using MarketDataApi.Wrapper.Models;

namespace MarketDataApi.Wrapper.Interfaces
{
	internal interface IOptionChain
	{
		Task<List<Chain>> V1OptionChainAsync(Format? format, string? underlying, DateTimeOffset? date = null, DateTimeOffset? expiration = null,
			DateTimeOffset? from = null, DateTimeOffset? to = null, int? month = null, int? year = null, bool? weekly = null, bool? monthly = null, bool? quarterly = null,
			int? dte = null, Side? side = null, Models.Range? range = null, float? strike = null, float? minOpenInterest = null, int? minVolume = null,
			float? maxBidAskSpread = null, float? maxBidAskSpreadPct = null, Dateformat? dateformat = null, int? limit = null, int? offset = null,
			bool? headers = null, string? columns = null, bool? symbol_lookup = null, bool? quote = null, bool? human = null);
	}
}