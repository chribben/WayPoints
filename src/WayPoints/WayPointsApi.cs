using System;
using System.Device.Location;
using System.Diagnostics.Contracts;

namespace WayPoints
{
    public class WayPointsApi
    {
        static public double CalculateDistanceSpeedingTo(WayPoint toWayPoint, WayPoint fromWayPoint)
        {
            Contract.Requires(toWayPoint != null);
            Contract.Requires(fromWayPoint != null);
            if (toWayPoint.Speed > toWayPoint.SpeedLimit)
            {
                return DistanceTo(toWayPoint, fromWayPoint);
            }
            return 0.0;
        }

        static public double DistanceTo(WayPoint toWayPoint, WayPoint fromWayPoint)
        {
            Contract.Requires(toWayPoint != null);
            Contract.Requires(fromWayPoint != null);
            var fromCoord = new GeoCoordinate(fromWayPoint.Position.Lat, fromWayPoint.Position.Long);
            var toCoord = new GeoCoordinate(toWayPoint.Position.Lat, toWayPoint.Position.Long);

            return fromCoord.GetDistanceTo(toCoord);

        }

        public static TimeSpan CalculateDurationSpeedingTo(WayPoint toWayPoint, WayPoint fromWayPoint)
        {
            Contract.Requires(toWayPoint != null);
            Contract.Requires(fromWayPoint != null);
            if (toWayPoint.Speed > toWayPoint.SpeedLimit)
            {
                return DurationTo(toWayPoint, fromWayPoint);
            }
            return new TimeSpan(0);
        }

        public static TimeSpan DurationTo(WayPoint toWayPoint, WayPoint fromWayPoint)
        {
            Contract.Requires(toWayPoint != null);
            Contract.Requires(fromWayPoint != null);
            return toWayPoint.TimeStamp.Subtract(fromWayPoint.TimeStamp);
        }
    }
}