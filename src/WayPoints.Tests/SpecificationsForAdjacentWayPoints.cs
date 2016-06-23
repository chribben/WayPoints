using System;
using NUnit.Framework;
namespace WayPoints.Tests
{
    public class SpecificationsForAdjacentWayPoints
    {
        //Speeding duration and distance is calculated from the previous way point 
        [Test]
        public void When_speeding_DistanceSpeeding_equals_distance_from_previous_WayPoint()
        {
            var previousWayPoint = new WayPoint { Position = new GpsCoords { Lat = 59.38, Long = 18.0665 } };
            var distance = WayPointsApi.CalculateDistanceSpeedingTo(SpeedingWayPoint, previousWayPoint);
            Assert.AreEqual(WayPointsApi.DistanceTo(SpeedingWayPoint, previousWayPoint), distance);
        }

        [Test]
        public void When_not_speeding_DistanceSpeeding_equals_zero()
        {
            var previousWayPoint = new WayPoint { Position = new GpsCoords { Lat = 59.38, Long = 18.0665 } };
            var distance = WayPointsApi.CalculateDistanceSpeedingTo(NonSpeedingWayPoint, previousWayPoint);
            Assert.AreEqual(0.0, distance);
        }

        [Test]
        public void When_speeding_DurationSpeeding_equals_time_from_previous_WayPoint()
        {
            var previousWayPoint = new WayPoint { TimeStamp = SpeedingWayPoint.TimeStamp.AddSeconds(-10) };
            var speedingDuration = WayPointsApi.CalculateDurationSpeedingTo(SpeedingWayPoint, previousWayPoint);
            Assert.AreEqual(WayPointsApi.DurationTo(SpeedingWayPoint, previousWayPoint), speedingDuration);
        }

        [Test]
        public void When_not_speeding_DurationSpeeding_equals_zero()
        {
            var previousWayPoint = new WayPoint { TimeStamp = NonSpeedingWayPoint.TimeStamp.AddSeconds(-10) };
            var speedingDuration = WayPointsApi.CalculateDurationSpeedingTo(NonSpeedingWayPoint, previousWayPoint);
            Assert.AreEqual(new TimeSpan(0), speedingDuration);
        }

        WayPoint SpeedingWayPoint = new WayPoint {
            TimeStamp = new DateTime(2016, 6, 23, 11, 36, 22),
            Position = new GpsCoords { Lat = 59.334, Long = 18.0667 },
            Speed = 9.4,
            SpeedLimit = 8.0 };
        WayPoint NonSpeedingWayPoint = new WayPoint {
            TimeStamp = new DateTime(2016, 6, 23, 11, 36, 22),
            Position = new GpsCoords { Lat = 59.3337, Long = 18.0662 },
            Speed = 7.4,
            SpeedLimit = 8.0 };
    }
}
