using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;

namespace MarketDataApi.Wrapper.Models
{
    public class Strike
    {
        public string Underlying { get; set; }
        public DateTime? Date { get; set; }
        public double? StrikePrice { get; set; }
        public DateTime? Updated { get; set; }
    }

    internal class StrikesResponse : BaseResponse
    {
        [JsonExtensionData]
        public Dictionary<string, JToken> Strikes { get; set; }
        public DateTime? Updated { get; set; }
    }        
}
