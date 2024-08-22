namespace MarketDataApi.Wrapper.Models
{
    public class IndexQuote
    {
        public string Symbol { get; set; }
		public double? Last { get; set; }
		public double? Change { get; set; }
        public double? ChangePct { get; set; }
        public DateTimeOffset? Updated { get; set; }
    }

    internal class IndexQuotesResponse : BaseResponse
    {
        public string[] Symbol { get; set; }
        public double?[] Last { get; set; }
        public double?[] Change { get; set; }
        public double?[] ChangePct { get; set; }
        public DateTimeOffset?[] Updated { get; set; }
    }
}