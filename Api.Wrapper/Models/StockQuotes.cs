namespace MarketDataApi.Wrapper.Models
{
    public class StockQuote
    {
        public string Symbol { get; set; }
        public double? Ask { get; set; }
        public double? AskSize { get; set; }
        public double? Bid { get; set; }
        public double? BidSize { get; set; }
        public double? Mid { get; set; }
        public double? Last { get; set; }
        public double? Change { get; set; }
        public double? ChangePct { get; set; }
        public long? Volume { get; set; }
        public DateTimeOffset? Updated { get; set; }
    }

    internal class StockQuotesResponse : BaseResponse
    {
        public string[] Symbol { get; set; }
        public double?[] Ask { get; set; }
        public double?[] AskSize { get; set; }
        public double?[] Bid { get; set; }
        public double?[] BidSize { get; set; }
        public double?[] Mid { get; set; }
        public double?[] Last { get; set; }
        public double?[] Change { get; set; }
        public double?[] ChangePct { get; set; }
        public long?[] Volume { get; set; }
        public DateTimeOffset?[] Updated { get; set; }
    }
}