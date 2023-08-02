﻿namespace MarketDataApi.Wrapper.Utils
{
    internal class GetValue
    {
        internal static T? Safe<T>(T[] values, int index)
        {
            if (values != null)
            {
                if (values.Length > index)
                {
                    return values[index];
                }
            }

            return default;
        }

        internal static DateTime? Safe(DateTime[] values, int index)
        {
            if (values != null)
            {
                if (values.Length > index)
                {
                    return values[index];
                }
            }

            return nullDate;
        }

        public static readonly DateTime? nullDate = null;
        public static readonly TimeSpan? nullTimeSpan = null;

        public static readonly byte? nullByte = null;
        public static readonly bool? nullBool = null;
        public static readonly Guid? nullGuid = null;

        public static readonly int? nullInt = null;
        public static readonly long? nullLong = null;
        public static readonly double? nullDouble = null;
        public static readonly decimal? nullDecimal = null;
        public static readonly float? nullFloat = null;
        public static readonly short? nullShort = null;
    }
}
