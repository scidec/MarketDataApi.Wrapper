using MarketDataApi.Wrapper.Models;
using MarketDataApi.Wrapper.Utils;
using System.Net;

namespace MarketDataApi.Wrapper.Handlers
{
    internal class OptionQuotes : Interfaces.BaseAPI, Interfaces.IOptionQuotes
    {
        private const string BaseUrl = @"https://api.marketdata.app/v1/options/quotes/{optionSymbol}/?";

        public OptionQuotes(string apiToken, IWebProxy proxy = null, string source = null) : base(apiToken, proxy, source)
        {
        }

        public async Task<List<Quote>> V1OptionQuotesAsync(Format? format, string optionSymbol, DateTimeOffset? date = null, DateTimeOffset? from = null, 
            DateTimeOffset? to = null, int? countback = null, Dateformat? dateformat = null, int? limit = null, int? offset = null, bool? headers = null, 
            string columns = null, bool? human = null)
        {
            if (optionSymbol == null)
                throw new ArgumentNullException("optionSymbol");

            var urlBuilder_ = new System.Text.StringBuilder(BaseUrl);

            string underlying = optionSymbol.Substring(0, 4);

            urlBuilder_.Replace("{optionSymbol}", Uri.EscapeDataString(ConvertToString(optionSymbol, System.Globalization.CultureInfo.InvariantCulture)));
            if (format != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("format") + "=").Append(Uri.EscapeDataString(ConvertToString(format, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (date != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("date") + "=").Append(Uri.EscapeDataString(date.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (from != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("from") + "=").Append(Uri.EscapeDataString(from.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (to != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("to") + "=").Append(Uri.EscapeDataString(to.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (countback != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("countback") + "=").Append(Uri.EscapeDataString(ConvertToString(countback, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
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
            if (human != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("human") + "=").Append(Uri.EscapeDataString(ConvertToString(human, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            var result = await ExecuteQueryAsync<QuotesResponse>(urlBuilder_.ToString());

            var total = result.Ask.Length;
            var items = new List<Quote>();

            for (int i = 0; i < total; i++)
            {
                items.Add(new Quote
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
                    OptionSymbol = optionSymbol,
                    Rho = GetValue.Safe(result.Rho, i),
                    Side = GetValue.Safe(result.Side, i),
                    Strike = GetValue.Safe(result.Strike, i),
                    Theta = GetValue.Safe(result.Theta, i),
                    //need to get from the request
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