using Newtonsoft.Json;

namespace LT.Models
{
    public class SearchFilterBus
    {
        public string from { get; set; }
        public string to { get; set; }
        public string travelDate { get; set; }
        public string affiliateCode { get; set; }

        [JsonProperty("include-connections")]
        public bool includeConnections { get; set; }
    }
}
