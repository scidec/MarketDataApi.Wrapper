namespace MarketDataApi.Wrapper.Models
{
	internal enum Format
	{
		Csv = 0,
		Json = 1,
	}

	internal enum Dateformat
	{
		Spreadsheet = 0,
		Timestamp = 1,
		Unix = 2,
	}

	public enum Side
	{
		Call = 0,
		Put = 1,
	}

	public enum Range
	{
		All = 0,
		Itm = 1,
		Otm = 2,
	}
}
