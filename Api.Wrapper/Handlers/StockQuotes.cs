﻿using MarketDataApi.Wrapper.Models;
using MarketDataApi.Wrapper.Utils;
using System.Net;

namespace MarketDataApi.Wrapper.Handlers
{
	internal class StockQuotes : Interfaces.BaseAPI, Interfaces.IStockQuotes
	{
		private const string BaseUrl = @"https://api.marketdata.app/v1/stocks/quotes/{stockSymbol}/?";

		public StockQuotes(string apiToken, IWebProxy? proxy = null, string? source = null) : base(apiToken, proxy, source)
		{
		}

		public async Task<StockQuote> V1StocksQuotesAsync(Format? format, string? stockSymbol, Dateformat? dateformat = null,
			int? limit = null, int? offset = null, bool? headers = null, string? columns = null, bool? symbol_lookup = null, bool? human = null)
		{
			if (stockSymbol == null)
				throw new ArgumentNullException(nameof(stockSymbol));

			var urlBuilder_ = new System.Text.StringBuilder(BaseUrl);
			urlBuilder_.Replace("{stockSymbol}", Uri.EscapeDataString(base.ConvertToString(stockSymbol, System.Globalization.CultureInfo.InvariantCulture)));

			if (format != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("format") + "=").Append(Uri.EscapeDataString(ConvertToString(format, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (dateformat != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("dateformat") + "=").Append(Uri.EscapeDataString(ConvertToString(dateformat, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (limit != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("limit") + "=").Append(Uri.EscapeDataString(ConvertToString(limit, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (offset != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("offset") + "=").Append(Uri.EscapeDataString(ConvertToString(offset, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (headers != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("headers") + "=").Append(Uri.EscapeDataString(ConvertToString(headers, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (columns != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("columns") + "=").Append(Uri.EscapeDataString(ConvertToString(columns, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (symbol_lookup != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("symbol_lookup") + "=").Append(Uri.EscapeDataString(ConvertToString(symbol_lookup, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			if (human != null)
			{
				urlBuilder_.Append(Uri.EscapeDataString("human") + "=").Append(Uri.EscapeDataString(ConvertToString(human, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
			}
			urlBuilder_.Length--;

			var result = await ExecuteQueryAsync<StockQuotesResponse>(urlBuilder_.ToString());

			var item = new StockQuote
			{
				Ask = GetValue.Safe(result.Ask, 0),
				AskSize = GetValue.Safe(result.AskSize, 0),
				Bid = GetValue.Safe(result.Bid, 0),
				BidSize = GetValue.Safe(result.BidSize, 0),
				Change = GetValue.Safe(result.Change, 0),
				ChangePct = GetValue.Safe(result.ChangePct, 0),
				Last = GetValue.Safe(result.Last, 0),
				Mid = GetValue.Safe(result.Mid, 0),
				Symbol = GetValue.Safe(result.Symbol, 0),
				Updated = GetValue.Safe(result.Updated, 0),
				Volume = GetValue.Safe(result.Volume, 0),
			};

			return item;
		}
	}
}