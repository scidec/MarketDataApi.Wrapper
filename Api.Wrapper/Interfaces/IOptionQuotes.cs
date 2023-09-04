using MarketDataApi.Wrapper.Models;

namespace MarketDataApi.Wrapper.Interfaces
{
    internal interface IOptionQuotes
    {
        Task<List<OptionQuote>> V1OptionQuotesAsync(Format? format, string optionSymbol, DateTimeOffset? date = null, DateTimeOffset? from = null,
            DateTimeOffset? to = null, int? countback = null, Dateformat? dateformat = null, int? limit = null, int? offset = null,
            bool? headers = null, string columns = null, bool? human = null);
    }
}
