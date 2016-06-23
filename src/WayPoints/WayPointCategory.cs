using System;

namespace WayPoints
{
    public class WayPointCategory
    {
        public double TotalDistance { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public double DistanceSpeeding { get; set; }
        public TimeSpan DurationSpeeding { get; set; }
    }
}
