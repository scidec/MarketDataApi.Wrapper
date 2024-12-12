namespace MarketDataApi.Wrapper.Models
{
	public class StockEarning
	{
		public string Symbol { get; set; }
		public int? FiscalYear { get; set; }
		public int? FiscalQuarter { get; set; }
		public DateTimeOffset? Date { get; set; }
		public DateTimeOffset? ReportDate { get; set; }
		public string? ReportTime { get; set; }
		public string? Currency { get; set; }
		public double? ReportedEPS { get; set; }
		public double? EstimatedEPS { get; set; }
		public double? SurpriseEPS { get; set; }
		public double? SurpriseEPSpct { get; set; }
		public DateTimeOffset? Updated { get; set; }
	}

	internal class StockEarningsResponse : BaseResponse
	{
		public string[] Symbol { get; set; }
		public int?[] FiscalYear { get; set; }
		public int?[] FiscalQuarter { get; set; }
		public DateTimeOffset?[] Date { get; set; }
		public DateTimeOffset?[] ReportDate { get; set; }
		public string?[] ReportTime { get; set; }
		public string?[] Currency { get; set; }
		public double?[] ReportedEPS { get; set; }
		public double?[] EstimatedEPS { get; set; }
		public double?[] SurpriseEPS { get; set; }
		public double?[] SurpriseEPSpct { get; set; }
		public DateTimeOffset?[] Updated { get; set; }
	}
}