using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoints
{
    public class GpsCoords
    {
        [JsonProperty(PropertyName = "latitude")]
        public double Lat { get; set; }
        [JsonProperty(PropertyName = "longitude")]
        public double Long { get; set; }
    }
}
