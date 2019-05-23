using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthquakeWPF
{
    public class RootObject
    {
        [JsonProperty("features")]
        public List<Feature> Features { get; set; }
    }
}
