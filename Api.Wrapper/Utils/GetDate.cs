namespace MarketDataApi.Wrapper.Utils
{
    internal class GetDate
    {
        internal static System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;

        internal static DateTime? ParseDate(string dateStr)
        {
            if (DateTime.TryParse(dateStr, out var date))
            {
                return date;
            }
            else
            {
                return GetValue.nullDate;
            }
        }

        internal static int LengthOfSymbol(string contractSymbol, out DateTime? result)
        {
            for (int i = 1; i < contractSymbol.Length - 1; i++)
            {
                if (DateTime.TryParseExact(contractSymbol.Substring(i, 6), "yyMMdd", provider, System.Globalization.DateTimeStyles.None, out DateTime dt))
                {
                    result = dt;
                    return i;
                }
            }

            result = GetValue.nullDate;
            return 0;
        }

        internal static int? DaysToExpiration(DateTime? date)
        {
            if (date == null) return GetValue.nullInt;
            DateTime now = DateTime.Now;
            TimeSpan ts = date.Value - now;
            return Fix(ts.TotalDays);
        }

        private static int Fix(double Number)
        {
            if (Number >= 0)
            {
                return (int)Math.Floor(Number);
            }
            return (int)Math.Ceiling(Number);
        }
    }
}
