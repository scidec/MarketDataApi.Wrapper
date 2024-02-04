using MarketDataApi.Wrapper.Models;
using MarketDataApi.Wrapper.Utils;
using System.Net;

namespace MarketDataApi.Wrapper.Handlers
{
    internal class StockEarnings : Interfaces.BaseAPI, Interfaces.IStockEarnings
    {
        private const string BaseUrl = @"https://api.marketdata.app/v1/stocks/earnings/{stockSymbol}/?";

        public StockEarnings(string apiToken, IWebProxy? proxy = null, string? source = null) : base(apiToken, proxy, source)
        {
        }

        public async Task<List<StockEarning>> V1StocksEarningsAsync(Format? format, string? stockSymbol, Dateformat? dateformat = null,
            DateTimeOffset? from = null, DateTimeOffset? to = null, int? countBack = null, DateTimeOffset? date = null, string? dateKey = null)
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
            if (date != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("date") + "=").Append(Uri.EscapeDataString(ConvertToString(date, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (dateKey != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("dateKey") + "=").Append(Uri.EscapeDataString(ConvertToString(dateKey, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            var result = await ExecuteQueryAsync<StockEarningsResponse>(urlBuilder_.ToString());

            var total = result.Symbol.Length;
            var items = new List<StockEarning>();

            for (int i = 0; i < total; i++)
            {
                items.Add(new StockEarning
                {
                    Currency = GetValue.Safe(result.Currency, 0),
                    Date = GetValue.Safe(result.Date, 0),
                    EstimatedEPS = GetValue.Safe(result.EstimatedEPS, 0),
                    FiscalQuarter = GetValue.Safe(result.FiscalQuarter, 0),
                    FiscalYear = GetValue.Safe(result.FiscalYear, 0),
                    ReportDate = GetValue.Safe(result.ReportDate, 0),
                    ReportedEPS = GetValue.Safe(result.ReportedEPS, 0),
                    ReportTime = GetValue.Safe(result.ReportTime, 0),
                    SurpriseEPS = GetValue.Safe(result.SurpriseEPS, 0),
                    SurpriseEPSpct = GetValue.Safe(result.SurpriseEPSpct, 0),
                    Symbol = GetValue.Safe(result.Symbol, 0),
                    Updated = GetValue.Safe(result.Updated, 0),
                });
            }

            return items;
        }
    }
}