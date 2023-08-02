namespace MarketDataApi.Wrapper.Models
{
    public class Expire
    {
        public string Underlying { get; set; }
        public DateTime? Expiration { get; set; }
        public DateTime? Updated { get; set; }
    }

    internal class ExpirationsResponse : BaseResponse
    {
        public DateTime?[] Expirations { get; set; }
        public DateTime? Updated { get; set; }
    }
}
