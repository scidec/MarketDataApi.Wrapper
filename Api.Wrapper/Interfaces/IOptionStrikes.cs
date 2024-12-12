using MarketDataApi.Wrapper.Models;

namespace MarketDataApi.Wrapper.Interfaces
{
	internal interface IOptionStrikes
	{
		public Task<List<Strike>> V1OptionStrikesAsync(Format? format, string? underlying, DateTimeOffset? date = null, DateTimeOffset? expiration = null,
			Dateformat? dateformat = null, int? limit = null, int? offset = null, bool? headers = null, string? columns = null, bool? symbol_lookup = null, bool? human = null);
	}
}
