using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoints
{
    public class WayPointsAggregationApi
    {
        public static IEnumerable<WayPointAggregation> GetCategorizationForEachWayPoint(IEnumerable<WayPoint> wayPoints)
        {
            var aggregatedWayPointData = new WayPointAggregation[wayPoints.Count()];
            var wayPointsArr = wayPoints.ToArray();
            double distanceSpeeding = 0;
            TimeSpan durationSpeeding = default(TimeSpan);
            TimeSpan totalDuration = default(TimeSpan);
            double totalDistance = 0;
            aggregatedWayPointData[0] = new WayPointAggregation
            {
                DistanceSpeeding = distanceSpeeding,
                DurationSpeeding = durationSpeeding,
                TotalDistance = totalDistance,
                TotalDuration = totalDuration
            };
            for (int i = 1; i < wayPointsArr.Length; i++)
            {
                distanceSpeeding = distanceSpeeding + WayPointsApi.CalculateDistanceSpeedingTo(wayPointsArr[i], wayPointsArr[i - 1]);
                durationSpeeding = durationSpeeding + WayPointsApi.CalculateDurationSpeedingTo(wayPointsArr[i], wayPointsArr[i - 1]);
                totalDuration = totalDuration + WayPointsApi.DurationTo(wayPointsArr[i], wayPointsArr[i - 1]);
                totalDistance = totalDistance + WayPointsApi.DistanceTo(wayPointsArr[i], wayPointsArr[i - 1]);
                aggregatedWayPointData[i] = new WayPointAggregation
                {
                    DistanceSpeeding = distanceSpeeding,
                    DurationSpeeding = durationSpeeding,
                    TotalDistance = totalDistance,
                    TotalDuration = totalDuration
                };
            }
            return aggregatedWayPointData;
        }
    }
    public class WayPointAggregation
    {
        public double TotalDistance { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public double DistanceSpeeding { get; set; }
        public TimeSpan DurationSpeeding { get; set; }
    }

}
