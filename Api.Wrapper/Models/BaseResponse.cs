namespace MarketDataApi.Wrapper.Models
{
    public class BaseResponse
    {
        /// <summary>
        /// Status
        /// </summary>
        public string S { get; set; }

        /// <summary>
        /// Error Message
        /// </summary>
        public string ErrMsg { get; set; }

        /// <summary>
        /// Next Time
        /// </summary>
        public DateTime? NextTime { get; set; }

        /// <summary>
        /// Previous Time
        /// </summary>
        public DateTime? PrevTime { get; set; }
    }
}
