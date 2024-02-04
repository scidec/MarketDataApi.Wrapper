using MarketDataApi.Wrapper.Models;

namespace MarketDataApi.Wrapper.Interfaces
{
    internal interface IStockQuotes
    {
        public Task<StockQuote> V1StocksQuotesAsync(Format? format, string? stockSymbol, Dateformat? dateformat = null,
            int? limit = null, int? offset = null, bool? headers = null, string? columns = null, bool? symbol_lookup = null, bool? human = null);
    }
}
