using MarketDataApi.Wrapper.Models;
using MarketDataApi.Wrapper.Utils;
using System.Net;

namespace MarketDataApi.Wrapper.Handlers
{
    internal class OptionChain : Interfaces.BaseAPI, Interfaces.IOptionChain
    {
        private const string BaseUrl = @"https://api.marketdata.app/v1/options/chain/{underlyingSymbol}/?";

        public OptionChain(string apiToken, IWebProxy proxy = null, string source = null) : base(apiToken, proxy, source)
        {
        }

        public async Task<List<Chain>> V1OptionChainAsync(Format? format, string underlying, DateTimeOffset? date = null, DateTimeOffset? expiration = null, 
            DateTimeOffset? from = null, DateTimeOffset? to = null, int? month = null, int? year = null, bool? weekly = null, bool? monthly = null, bool? quarterly = null,
            int? dte = null, Side? side = null, Models.Range? range = null, float? strike = null, float? minOpenInterest = null, int? minVolume = null, 
            float? maxBidAskSpread = null, float? maxBidAskSpreadPct = null, Dateformat? dateformat = null, int? limit = null, int? offset = null, 
            bool? headers = null, string columns = null, bool? symbol_lookup = null, bool? quote = null, bool? human = null)
        {
            if (underlying == null)
                throw new ArgumentNullException("underlying");

            var urlBuilder_ = new System.Text.StringBuilder(BaseUrl);

            urlBuilder_.Replace("{underlyingSymbol}", Uri.EscapeDataString(ConvertToString(underlying, System.Globalization.CultureInfo.InvariantCulture)));
            if (format != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("format") + "=").Append(Uri.EscapeDataString(ConvertToString(format, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (date != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("date") + "=").Append(Uri.EscapeDataString(date.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (expiration != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("expiration") + "=").Append(Uri.EscapeDataString(expiration.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (from != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("from") + "=").Append(Uri.EscapeDataString(from.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (to != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("to") + "=").Append(Uri.EscapeDataString(to.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (month != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("month") + "=").Append(Uri.EscapeDataString(ConvertToString(month, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (year != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("year") + "=").Append(Uri.EscapeDataString(ConvertToString(year, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (weekly != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("weekly") + "=").Append(Uri.EscapeDataString(ConvertToString(weekly, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (monthly != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("monthly") + "=").Append(Uri.EscapeDataString(ConvertToString(monthly, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (quarterly != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("quarterly") + "=").Append(Uri.EscapeDataString(ConvertToString(quarterly, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (dte != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("dte") + "=").Append(Uri.EscapeDataString(ConvertToString(dte, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (side != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("side") + "=").Append(Uri.EscapeDataString(ConvertToString(side, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (range != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("range") + "=").Append(Uri.EscapeDataString(ConvertToString(range, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (strike != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("strike") + "=").Append(Uri.EscapeDataString(ConvertToString(strike, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (minOpenInterest != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("minOpenInterest") + "=").Append(Uri.EscapeDataString(ConvertToString(minOpenInterest, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (minVolume != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("minVolume") + "=").Append(Uri.EscapeDataString(ConvertToString(minVolume, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (maxBidAskSpread != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("maxBidAskSpread") + "=").Append(Uri.EscapeDataString(ConvertToString(maxBidAskSpread, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (maxBidAskSpreadPct != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("maxBidAskSpreadPct") + "=").Append(Uri.EscapeDataString(ConvertToString(maxBidAskSpreadPct, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
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
            if (quote != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("quote") + "=").Append(Uri.EscapeDataString(ConvertToString(quote, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (human != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("human") + "=").Append(Uri.EscapeDataString(ConvertToString(human, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            var result = await ExecuteQueryAsync<ChainsResponse>(urlBuilder_.ToString());

            var items = new List<Chain>();

            var total = result.Ask.Length;

            //need to populate these
            //"expiration": null,
            //"side": null,
            //"strike": null,
            //"firstTraded": null,
            //"dte": null,

            for (int i = 0; i < total; i++)
            {
                items.Add(new Chain
                {
                    Ask = GetValue.Safe(result.Ask, i),
                    AskSize = GetValue.Safe(result.AskSize, i),
                    Bid = GetValue.Safe(result.Bid, i),
                    BidSize = GetValue.Safe(result.BidSize, i),
                    Delta = GetValue.Safe(result.Delta, i),
                    DTE = GetValue.Safe(result.DTE, i),
                    Expiration = GetValue.Safe(result.Expiration, i),
                    ExtrinsicValue = GetValue.Safe(result.ExtrinsicValue, i),
                    FirstTraded = GetValue.Safe(result.FirstTraded, i),
                    Gamma = GetValue.Safe(result.Gamma, i),
                    InTheMoney = GetValue.Safe(result.InTheMoney, i),
                    IntrinsicValue = GetValue.Safe(result.IntrinsicValue, i),
                    IV = GetValue.Safe(result.IV, i),
                    Last = GetValue.Safe(result.Last, i),
                    Mid = GetValue.Safe(result.Mid, i),
                    OpenInterest = GetValue.Safe(result.OpenInterest, i),
                    OptionSymbol = GetValue.Safe(result.OptionSymbol, i),
                    Rho = GetValue.Safe(result.Rho, i),
                    Side = GetValue.Safe(result.Side, i),
                    Strike = GetValue.Safe(result.Strike, i),
                    Theta = GetValue.Safe(result.Theta, i),
                    Underlying = underlying,
                    UnderlyingPrice = GetValue.Safe(result.UnderlyingPrice, i),
                    Updated = GetValue.Safe(result.Updated, i),
                    Vega = GetValue.Safe(result.Vega, i),
                    Volume = GetValue.Safe(result.Volume, i),
                });
            }

            return items;
        }
    }
}
