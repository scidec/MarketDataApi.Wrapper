namespace MarketDataApi.Wrapper.Models
{
    public class Expire
    {
        public string Underlying { get; set; }
        public DateTimeOffset? Expiration { get; set; }
        public DateTimeOffset? Updated { get; set; }
    }

    internal class ExpirationsResponse : BaseResponse
    {
        public DateTimeOffset?[] Expirations { get; set; }
        public DateTimeOffset? Updated { get; set; }
    }
}
