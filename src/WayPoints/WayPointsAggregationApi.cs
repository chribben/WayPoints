using System;
using System.Collections.Generic;
using System.Linq;

namespace WayPoints
{
    public class WayPointsCategorizationApi
    {
        public static IEnumerable<WayPointCategory> GetCategorizationForEachWayPoint(IEnumerable<WayPoint> wayPoints)
        {
            var aggregatedWayPointData = new WayPointCategory[wayPoints.Count()];
            var wayPointsArr = wayPoints.ToArray();
            double distanceSpeeding = 0;
            TimeSpan durationSpeeding = default(TimeSpan);
            TimeSpan totalDuration = default(TimeSpan);
            double totalDistance = 0;
            aggregatedWayPointData[0] = new WayPointCategory
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
                aggregatedWayPointData[i] = new WayPointCategory
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
}
