using MarketDataApi.Wrapper.Models;
using MarketDataApi.Wrapper.Utils;
using System.Net;

namespace MarketDataApi.Wrapper.Handlers
{
	internal class OptionExpirations : Interfaces.BaseAPI, Interfaces.IOptionExpirations
	{
		private const string BaseUrl = @"https://api.marketdata.app/v1/options/expirations/{underlyingSymbol}/?";

		public OptionExpirations(string apiToken, IWebProxy? proxy = null, string? source = null) : base(apiToken, proxy, source)
		{
		}

		public async Task<List<Expire>> V1OptionExpirationsAsync(Format? format, string? underlying, float? strike = null, DateTimeOffset? date = null,
			Dateformat? dateformat = null, int? limit = null, int? offset = null, bool? headers = null, string? columns = null, bool? symbol_lookup = null, bool? human = null)
		{
			if (underlying == null)
				throw new ArgumentNullException(nameof(underlying));

			var urlBuilder_ = new System.Text.StringBuilder(BaseUrl);

			urlBuilder_.Replace("{underlyingSymbol}", Uri.EscapeDataString(base.ConvertToString(underlying, System.Globalization.CultureInfo.InvariantCulture)));
			if (format != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("format") + "=").Append(Uri.EscapeDataString(base.ConvertToString(format, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (strike != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("strike") + "=").Append(Uri.EscapeDataString(base.ConvertToString(strike, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (date != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("date") + "=").Append(Uri.EscapeDataString(base.ConvertToString(date, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (dateformat != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("dateformat") + "=").Append(Uri.EscapeDataString(base.ConvertToString(dateformat, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (limit != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("limit") + "=").Append(Uri.EscapeDataString(base.ConvertToString(limit, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (offset != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("offset") + "=").Append(Uri.EscapeDataString(base.ConvertToString(offset, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (headers != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("headers") + "=").Append(Uri.EscapeDataString(base.ConvertToString(headers, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (columns != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("columns") + "=").Append(Uri.EscapeDataString(base.ConvertToString(columns, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (symbol_lookup != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("symbol_lookup") + "=").Append(Uri.EscapeDataString(base.ConvertToString(symbol_lookup, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (human != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("human") + "=").Append(Uri.EscapeDataString(base.ConvertToString(human, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			urlBuilder_.Length--;

			var result = await ExecuteQueryAsync<ExpirationsResponse>(urlBuilder_.ToString());

			var items = new List<Expire>();
			var total = result.Expirations?.Length;

			for (int i = 0; i < total; i++)
			{
				items.Add(new Expire
				{
					Expiration = GetValue.Safe(result.Expirations, i),
					Underlying = underlying,
					Updated = result.Updated
				});
			}

			return items;
		}

	}
}
