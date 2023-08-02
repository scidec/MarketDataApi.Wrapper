namespace MarketDataApi.Wrapper.Utils
{
    internal class GetDate
    {
        internal static DateTime? ParseDate(string dateStr)
        {
            if (DateTime.TryParse(dateStr, out var date))
            {
                return date;
            }
            else
            {
                return null;
            }
        }
    }
}
