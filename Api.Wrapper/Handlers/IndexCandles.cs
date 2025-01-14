using MarketDataApi.Wrapper.Models;
using MarketDataApi.Wrapper.Utils;
using System.Net;

namespace MarketDataApi.Wrapper.Handlers
{
	internal class IndexCandles : Interfaces.BaseAPI, Interfaces.IIndexCandles
	{
		private const string BaseUrl = @"https://api.marketdata.app/v1/indices/candles/{resolution}/{stockSymbol}/?";

		public IndexCandles(string apiToken, IWebProxy? proxy = null, string? source = null) : base(apiToken, proxy, source)
		{
		}

		public async Task<List<IndexCandle>> V1IndexCandlesAsync(Format? format, string? stockSymbol, string? resolution,
			Dateformat? dateformat = null, DateTimeOffset? from = null, DateTimeOffset? to = null,
			int? countBack = null, bool? extended = null, bool? adjustsplits = null)
		{
			if (stockSymbol == null)
				throw new ArgumentNullException(nameof(stockSymbol));

			if (resolution == null)
				throw new ArgumentNullException(nameof(resolution));

			var urlBuilder_ = new System.Text.StringBuilder(BaseUrl);
			urlBuilder_.Replace("{stockSymbol}", Uri.EscapeDataString(base.ConvertToString(stockSymbol, System.Globalization.CultureInfo.InvariantCulture)));
			urlBuilder_.Replace("{resolution}", Uri.EscapeDataString(base.ConvertToString(resolution, System.Globalization.CultureInfo.InvariantCulture)));

			if (format != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("format") + "=").Append(Uri.EscapeDataString(ConvertToString(format, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (dateformat != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("dateformat") + "=").Append(Uri.EscapeDataString(ConvertToString(dateformat, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (from != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("from") + "=").Append(Uri.EscapeDataString(ConvertToString(from, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (to != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("to") + "=").Append(Uri.EscapeDataString(ConvertToString(to, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (countBack != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("countBack") + "=").Append(Uri.EscapeDataString(ConvertToString(countBack, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (extended != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("extended") + "=").Append(Uri.EscapeDataString(ConvertToString(extended, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (adjustsplits != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("adjustsplits") + "=").Append(Uri.EscapeDataString(ConvertToString(adjustsplits, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}

			urlBuilder_.Length--;

			var result = await ExecuteQueryAsync<IndexCandleResponse>(urlBuilder_.ToString());
			var total = result.H.Length;
			var items = new List<IndexCandle>();

			for (int i = 0; i < total; i++)
			{

				items.Add(new IndexCandle
				{
					Symbol = stockSymbol,
					High = GetValue.Safe(result.H, i),
					Low = GetValue.Safe(result.L, i),
					Open = GetValue.Safe(result.O, i),
					Close = GetValue.Safe(result.C, i),
					Volume = GetValue.Safe(result.V, i),
					Time = GetDate.ParseDate(GetValue.Safe(result.T, i)),
				});
			}

			return items;
		}
	}
}