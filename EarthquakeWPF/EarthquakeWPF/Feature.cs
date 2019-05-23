using Newtonsoft.Json;

namespace EarthquakeWPF
{
    public class Feature
    {
        [JsonProperty("properties")]
        public Property Properties { get; set; }
    }
}