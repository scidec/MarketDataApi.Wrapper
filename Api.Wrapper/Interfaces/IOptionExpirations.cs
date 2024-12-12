using MarketDataApi.Wrapper.Models;

namespace MarketDataApi.Wrapper.Interfaces
{
	internal interface IOptionExpirations
	{
		Task<List<Expire>> V1OptionExpirationsAsync(Format? format, string? underlying, float? strike = null,
			DateTimeOffset? date = null, Dateformat? dateformat = null, int? limit = null, int? offset = null,
			bool? headers = null, string? columns = null, bool? symbol_lookup = null, bool? human = null);
	}
}
