namespace MarketDataApi.Wrapper.Models
{
    public class Lookup
    {
        public string OptionSymbol { get; set; }
    }

    internal class LookupResponse : BaseResponse
    {
        public string OptionSymbol { get; set; }
    }
}