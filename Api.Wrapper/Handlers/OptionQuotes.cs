using MarketDataApi.Wrapper.Models;
using MarketDataApi.Wrapper.Utils;
using System.Net;

namespace MarketDataApi.Wrapper.Handlers
{
    internal class OptionQuotes : Interfaces.BaseAPI, Interfaces.IOptionQuotes
    {
        private const string BaseUrl = @"https://api.marketdata.app/v1/options/quotes/{optionSymbol}/?";

        public OptionQuotes(string apiToken, IWebProxy? proxy = null, string? source = null) : base(apiToken, proxy, source)
        {
        }

        public async Task<List<OptionQuote>> V1OptionQuotesAsync(Format? format, string? optionSymbol, DateTimeOffset? date = null, DateTimeOffset? from = null,
            DateTimeOffset? to = null, int? countback = null, Dateformat? dateformat = null, int? limit = null, int? offset = null, bool? headers = null,
            string? columns = null, bool? human = null)
        {
            if (optionSymbol == null)
                throw new ArgumentNullException(nameof(optionSymbol));

            var urlBuilder_ = new System.Text.StringBuilder(BaseUrl);

            //TODO: need to populate these from the response instead
            #region Remove
            //"expiration": null,
            //"side": null,
            //"strike": null,
            //"firstTraded": null,
            //"dte": null,

            //get parameters from option symbol, but should be in the reponse
            string underlying = null;
            int? daysToExpiry = null;
            string callOrPut = null;
            double? strike = null;

            int underlyingLocation = GetDate.LengthOfSymbol(optionSymbol, out DateTimeOffset? expiryDate);
            if (underlyingLocation > 0)
            {
                underlying = optionSymbol.Substring(0, underlyingLocation);
                expiryDate = expiryDate.Value.AddDays(1).AddSeconds(-1); //end of the day
                daysToExpiry = GetDate.DaysToExpiration(expiryDate);
                callOrPut = optionSymbol.Substring(underlyingLocation + 6, 1) == "P" ? "put" : "call";
                strike = Convert.ToDouble(optionSymbol.Substring(underlyingLocation + 8)) / 1000d;
            }
            #endregion

            urlBuilder_.Replace("{optionSymbol}", Uri.EscapeDataString(base.ConvertToString(optionSymbol, System.Globalization.CultureInfo.InvariantCulture)));
            if (format != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("format") + "=").Append(Uri.EscapeDataString(base.ConvertToString(format, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (date != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("date") + "=").Append(Uri.EscapeDataString(base.ConvertToString(date.Value, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (from != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("from") + "=").Append(Uri.EscapeDataString(base.ConvertToString(from.Value, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (to != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("to") + "=").Append(Uri.EscapeDataString(base.ConvertToString(to.Value, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (countback != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("countback") + "=").Append(Uri.EscapeDataString(base.ConvertToString(countback, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
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
            if (human != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("human") + "=").Append(Uri.EscapeDataString(base.ConvertToString(human, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            var result = await ExecuteQueryAsync<OptionQuotesResponse>(urlBuilder_.ToString());

            var total = result.Ask.Length;
            var items = new List<OptionQuote>();

            for (int i = 0; i < total; i++)
            {
                items.Add(new OptionQuote
                {
                    Ask = GetValue.Safe(result.Ask, i),
                    AskSize = GetValue.Safe(result.AskSize, i),
                    Bid = GetValue.Safe(result.Bid, i),
                    BidSize = GetValue.Safe(result.BidSize, i),
                    Delta = GetValue.Safe(result.Delta, i),
                    DTE = daysToExpiry, //GetValue.Safe(result.DTE, i),
                    Expiration = expiryDate, //GetValue.Safe(result.Expiration, i),
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
                    Side = callOrPut, //GetValue.Safe(result.Side, i),
                    Strike = strike, //GetValue.Safe(result.Strike, i),
                    Theta = GetValue.Safe(result.Theta, i),
                    Underlying = underlying, //GetValue.Safe(result.Underlying, i),
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