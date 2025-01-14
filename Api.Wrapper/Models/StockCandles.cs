namespace MarketDataApi.Wrapper.Models
{
	public class StockCandle
	{
		public string Symbol { get; set; }
		public DateTimeOffset? Time { get; set; }
		public double? High { get; set; }
		public double? Low { get; set; }
		public double? Open { get; set; }
		public double? Close { get; set; }
		public long? Volume { get; set; }
	}

	internal class StockCandleResponse : BaseResponse
	{
		public string[] T { get; set; }
		public double?[] H { get; set; }
		public double?[] L { get; set; }
		public double?[] O { get; set; }
		public double?[] C { get; set; }
		public long?[] V { get; set; }
	}
}