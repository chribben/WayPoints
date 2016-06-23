using Newtonsoft.Json;
using System;

namespace WayPoints
{
    public class WayPoint
    {
        [JsonProperty(PropertyName = "position")]
        public GpsCoords Position { get; set; }
        [JsonProperty(PropertyName = "speed")]
        public double Speed { get; set; }
        [JsonProperty(PropertyName = "speed_limit")]
        public double SpeedLimit { get; set; }
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime TimeStamp { get; set; }
    }
}