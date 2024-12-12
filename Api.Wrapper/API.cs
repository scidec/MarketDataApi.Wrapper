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
		private readonly Wrapper.Interfaces.IStockQuotes _stockQuotes;
		private readonly Wrapper.Interfaces.IStockEarnings _stockEarnings;
		private readonly Wrapper.Interfaces.IIndexQuotes _indexQuotes;

		public API(string apiKey, IWebProxy? proxy = null, string? source = null)
		{
			_optionChain = new Wrapper.Handlers.OptionChain(apiKey, proxy, source);
			_optionExpirations = new Wrapper.Handlers.OptionExpirations(apiKey, proxy, source);
			_optionQuotes = new Wrapper.Handlers.OptionQuotes(apiKey, proxy, source);
			_optionStrikes = new Wrapper.Handlers.OptionsStrikes(apiKey, proxy, source);
			_optionLookups = new Wrapper.Handlers.OptionLookup(apiKey, proxy, source);
			_stockQuotes = new Wrapper.Handlers.StockQuotes(apiKey, proxy, source);
			_stockEarnings = new Wrapper.Handlers.StockEarnings(apiKey, proxy, source);
			_indexQuotes = new Wrapper.Handlers.IndexQuotes(apiKey, proxy, source);
		}

		public async Task<List<OptionQuote>> V1OptionQuotesAsync(string? optionSymbol, DateTimeOffset? date = null, DateTimeOffset? from = null, DateTimeOffset? to = null, int? countback = null, int? limit = null, int? offset = null, bool? headers = null, string? columns = null, bool? human = null)
		{
			//force json and timestamp since we are in .net and the web
			return await _optionQuotes.V1OptionQuotesAsync(Format.Json, optionSymbol, date, from, to, countback, Dateformat.Timestamp, limit, offset, headers, columns, human);
		}

		public async Task<List<Strike>> V1OptionStrikesAsync(string? underlying, DateTimeOffset? date = null, DateTimeOffset? expiration = null, int? limit = null, int? offset = null, bool? headers = null, string? columns = null, bool? symbol_lookup = null, bool? human = null)
		{
			//force json and timestamp since we are in .net and the web
			return await _optionStrikes.V1OptionStrikesAsync(Format.Json, underlying, date, expiration, Dateformat.Timestamp, limit, offset, headers, columns, symbol_lookup, human);
		}

		public async Task<List<Chain>> V1OptionChainAsync(string? underlying, DateTimeOffset? date = null, DateTimeOffset? expiration = null, DateTimeOffset? from = null, DateTimeOffset? to = null,
			int? month = null, int? year = null, bool? weekly = null, bool? monthly = null, bool? quarterly = null, int? dte = null, Side? side = null, Wrapper.Models.Range? range = null, float? strike = null, float? minOpenInterest = null, int? minVolume = null,
			float? maxBidAskSpread = null, float? maxBidAskSpreadPct = null, int? limit = null, int? offset = null, bool? headers = null, string? columns = null, bool? symbol_lookup = null, bool? quote = null, bool? human = null)
		{
			//force json and timestamp since we are in .net and the web
			return await _optionChain.V1OptionChainAsync(Format.Json, underlying, date, expiration, from, to, month, year, weekly, monthly, quarterly, dte, side, range, strike, minOpenInterest, minVolume, maxBidAskSpread, maxBidAskSpreadPct, Dateformat.Timestamp, limit, offset, headers, columns, symbol_lookup, quote, human);
		}

		public async Task<List<Expire>> V1OptionExpirationsAsync(string? underlying, float? strike = null,
			DateTimeOffset? date = null, int? limit = null, int? offset = null,
			bool? headers = null, string? columns = null, bool? symbol_lookup = null, bool? human = null)
		{
			//force json and timestamp since we are in .net and the web
			return await _optionExpirations.V1OptionExpirationsAsync(Format.Json, underlying, strike, date, Dateformat.Timestamp, limit, offset, headers, columns, symbol_lookup, human);
		}

		public async Task<Lookup> V1OptionLookupAsync(string? userInput)
		{
			//force json since we are in .net and the web
			return await _optionLookups.V1OptionSymbolLookupAsync(Format.Json, userInput);
		}

		public async Task<StockQuote> V1StockQuotesAsync(string? stockSymbol, int? limit = null, int? offset = null, bool? headers = null, string? columns = null, bool? symbol_lookup = null, bool? human = null)
		{
			return await _stockQuotes.V1StocksQuotesAsync(Format.Json, stockSymbol, Dateformat.Timestamp, limit, offset, headers, columns, symbol_lookup, human);
		}

		public async Task<List<StockEarning>> V1StockEarningsAsync(string? stockSymbol, DateTimeOffset? from = null, DateTimeOffset? to = null, int? countBack = null, DateTimeOffset? date = null, string? dateKey = null)
		{
			return await _stockEarnings.V1StockEarningsAsync(Format.Json, stockSymbol, Dateformat.Timestamp, from, to, countBack, date, dateKey);
		}

		public async Task<IndexQuote> V1IndexQuotesAsync(string? stockSymbol, int? limit = null, int? offset = null, bool? headers = null, string? columns = null, bool? symbol_lookup = null, bool? human = null)
		{
			return await _indexQuotes.V1IndexQuotesAsync(Format.Json, stockSymbol, Dateformat.Timestamp, limit, offset, headers, columns, symbol_lookup, human);
		}
	}
}
