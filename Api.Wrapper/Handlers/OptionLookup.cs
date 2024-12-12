using MarketDataApi.Wrapper.Models;
using System.Net;

namespace MarketDataApi.Wrapper.Handlers
{
	internal class OptionLookup : Interfaces.BaseAPI, Interfaces.IOptionLookup
	{
		private const string BaseUrl = @"https://api.marketdata.app/v1/options/lookup/{userInput}/?";

		public OptionLookup(string apiToken, IWebProxy? proxy = null, string? source = null) : base(apiToken, proxy, source)
		{
		}

		public async Task<Lookup> V1OptionSymbolLookupAsync(Format? format, string? userInput)
		{
			if (userInput == null)
				throw new ArgumentNullException(nameof(userInput));

			var urlBuilder_ = new System.Text.StringBuilder(BaseUrl);

			urlBuilder_.Replace("{userInput}", Uri.EscapeDataString(base.ConvertToString(userInput, System.Globalization.CultureInfo.InvariantCulture)));
			if (format != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("format") + "=").Append(Uri.EscapeDataString(base.ConvertToString(format, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			urlBuilder_.Length--;

			var result = await ExecuteQueryAsync<LookupResponse>(urlBuilder_.ToString());

			return new Lookup { OptionSymbol = result.OptionSymbol };
		}
	}
}
