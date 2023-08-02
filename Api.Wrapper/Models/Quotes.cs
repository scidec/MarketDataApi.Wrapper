namespace MarketDataApi.Wrapper.Models
{
    public class Quote
    {
        public string OptionSymbol { get; set; }
        public string Underlying { get; set; }
        public DateTime? Expiration { get; set; }
        public string Side { get; set; }
        public double? Strike { get; set; }
        public DateTime? FirstTraded { get; set; }
        public int? DTE { get; set; }
        public DateTime? Updated { get; set; }
        public double? Bid { get; set; }
        public double? BidSize { get; set; }
        public double? Mid { get; set; }
        public double? Ask { get; set; }
        public double? AskSize { get; set; }
        public double? Last { get; set; }
        public double? OpenInterest { get; set; }
        public double? Volume { get; set; }
        public bool? InTheMoney { get; set; }
        public double? IntrinsicValue { get; set; }
        public double? ExtrinsicValue { get; set; }
        public double? UnderlyingPrice { get; set; }
        public double? IV { get; set; }
        public double? Delta { get; set; }
        public double? Gamma { get; set; }
        public double? Theta { get; set; }
        public double? Vega { get; set; }
        public double? Rho { get; set; }
    }

    internal class QuotesResponse : BaseResponse
    {
        public string[] OptionSymbol { get; set; }
        public double?[] Underlying { get; set; }
        public DateTime?[] Expiration { get; set; }
        public string[] Side { get; set; }
        public double?[] Strike { get; set; }
        public DateTime?[] FirstTraded { get; set; }
        public int?[] DTE { get; set; }
        public DateTime?[] Updated { get; set; }
        public double?[] Bid { get; set; }
        public double?[] BidSize { get; set; }
        public double?[] Mid { get; set; }
        public double?[] Ask { get; set; }
        public double?[] AskSize { get; set; }
        public double?[] Last { get; set; }
        public double?[] OpenInterest { get; set; }
        public double?[] Volume { get; set; }
        public bool?[] InTheMoney { get; set; }
        public double?[] IntrinsicValue { get; set; }
        public double?[] ExtrinsicValue { get; set; }
        public double?[] UnderlyingPrice { get; set; }
        public double?[] IV { get; set; }
        public double?[] Delta { get; set; }
        public double?[] Gamma { get; set; }
        public double?[] Theta { get; set; }
        public double?[] Vega { get; set; }
        public double?[] Rho { get; set; }
    }
}
