using MarketDataApi.Wrapper.Models;
using System.Net;

namespace MarketDataApi
{
    public class API : Wrapper.Interfaces.IAPI
    {
        private readonly Wrapper.Interfaces.IOptionChain _optionChain;
        private readonly Wrapper.Interfaces.IOptionExpirations _optionExpirations;
        private readonly Wrapper.Interfaces.IOptionQuotes _optionQuotes;
        private readonly Wrapper.Interfaces.IOptionStrikes _optionStrikes;
        private readonly Wrapper.Interfaces.IOptionLookup _optionLookups;

        public API(string apiKey, IWebProxy proxy = null, string source = null)
        {
            _optionChain = new Wrapper.Handlers.OptionChain(apiKey, proxy, source);
            _optionExpirations = new Wrapper.Handlers.OptionExpirations(apiKey, proxy, source);
            _optionQuotes = new Wrapper.Handlers.OptionQuotes(apiKey, proxy, source);
            _optionStrikes = new Wrapper.Handlers.OptionsStrikes(apiKey, proxy, source);
            _optionLookups = new Wrapper.Handlers.OptionLookup(apiKey, proxy, source);
        }

        public async Task<List<Quote>> V1OptionQuotesAsync(string optionSymbol, DateTimeOffset? date = null, DateTimeOffset? from = null, DateTimeOffset? to = null, int? countback = null, int? limit = null, int? offset = null, bool? headers = null, string columns = null, bool? human = null)
        {
            //force json and timestamp since we are in .net and the web
            return await _optionQuotes.V1OptionQuotesAsync(Format.Json, optionSymbol, date, from, to, countback, Dateformat.Timestamp, limit, offset, headers, columns, human);
        }

        public async Task<List<Strike>> V1OptionStrikesAsync(string underlying, DateTimeOffset? date = null, DateTimeOffset? expiration = null, int? limit = null, int? offset = null, bool? headers = null, string columns = null, bool? symbol_lookup = null, bool? human = null)
        {
            //force json and timestamp since we are in .net and the web
            return await _optionStrikes.V1OptionStrikesAsync(Format.Json, underlying, date, expiration, Dateformat.Timestamp, limit, offset, headers, columns, symbol_lookup, human);
        }

        public async Task<List<Chain>> V1OptionChainAsync(string underlying, DateTimeOffset? date = null, DateTimeOffset? expiration = null, DateTimeOffset? from = null, DateTimeOffset? to = null,
            int? month = null, int? year = null, bool? weekly = null, bool? monthly = null, bool? quarterly = null, int? dte = null, Side? side = null, Wrapper.Models.Range? range = null, float? strike = null, float? minOpenInterest = null, int? minVolume = null,
            float? maxBidAskSpread = null, float? maxBidAskSpreadPct = null, int? limit = null, int? offset = null, bool? headers = null, string columns = null, bool? symbol_lookup = null, bool? quote = null, bool? human = null)
        {
            //force json and timestamp since we are in .net and the web
            return await _optionChain.V1OptionChainAsync(Format.Json, underlying, date, expiration, from, to, month, year, weekly, monthly, quarterly, dte, side, range, strike, minOpenInterest, minVolume, maxBidAskSpread, maxBidAskSpreadPct, Dateformat.Timestamp, limit, offset, headers, columns, symbol_lookup, quote, human);
        }

        public async Task<List<Expire>> V1OptionExpirationsAsync(string underlying, float? strike = null,
            DateTimeOffset? date = null, int? limit = null, int? offset = null,
            bool? headers = null, string columns = null, bool? symbol_lookup = null, bool? human = null)
        {
            //force json and timestamp since we are in .net and the web
            return await _optionExpirations.V1OptionExpirationsAsync(Format.Json, underlying, strike, date, Dateformat.Timestamp, limit, offset, headers, columns, symbol_lookup, human);
        }

        public async Task<Lookup> V1OptionLookupAsync(string userInput)
        {
            //force json since we are in .net and the web
            return await _optionLookups.V1OptionSymbolLookupAsync(Format.Json, userInput);
        }
    }
}
