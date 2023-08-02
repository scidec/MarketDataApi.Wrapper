using MarketDataApi.Wrapper.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace MarketDataApi.Wrapper.Handlers
{
    internal class OptionsStrikes : Interfaces.BaseAPI, Interfaces.IOptionStrikes
    {
        private const string BaseUrl = @"https://api.marketdata.app/v1/options/strikes/{underlyingSymbol}/?";

        public OptionsStrikes(string apiToken, IWebProxy proxy = null, string source = null) : base(apiToken, proxy, source)
        {
        }

        public async Task<List<Strike>> V1OptionStrikesAsync(Format? format, string underlying, DateTimeOffset? date = null, DateTimeOffset? expiration = null,
            Dateformat? dateformat = null, int? limit = null, int? offset = null, bool? headers = null, string columns = null, bool? symbol_lookup = null, bool? human = null)
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

            var content = await ExecuteQueryAsync(urlBuilder_.ToString());
            var result = JsonConvert.DeserializeObject<StrikesResponse>(content);
            var resultx = JsonConvert.DeserializeObject<Dictionary<string, JToken>>(content);
            var items = new List<Strike>();

            foreach (var row in resultx.Keys)
            {
                if (row != "updated" && row != "s")
                {
                    foreach (var item in resultx[row])
                    {
                        var x = Convert.ToDouble(item);

                        items.Add(new Strike
                        {
                            Updated = result.Updated,
                            Date = DateTime.ParseExact(row, "yyyy-MM-dd", null),
                            StrikePrice = x,
                            Underlying = underlying,
                        });
                    }
                }
            }

            return items;
        }
    }
}
