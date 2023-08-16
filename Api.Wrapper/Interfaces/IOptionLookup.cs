using MarketDataApi.Wrapper.Models;

namespace MarketDataApi.Wrapper.Interfaces
{
    internal interface IOptionLookup
    {
        Task<Lookup> V1OptionSymbolLookupAsync(Format? format, string userInput);
    }
}
