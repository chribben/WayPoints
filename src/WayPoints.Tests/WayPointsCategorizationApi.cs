using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace WayPoints.Tests
{
    public class WayPointsCategorizationApi
    {
        [Test]
        public void Categorization_of_empty_json_returns_empty_collection()
        {
            var result = WayPoints.WayPointsCategorizationApi.GetCategorizationForEachWayPoint(new WayPoint[0]);
            Assert.That(result, Is.Empty);
        }
        [Test]
        public void Passing_null_to_categorization_method_does_not_throw()
        {
            Assert.DoesNotThrow(() => WayPoints.WayPointsCategorizationApi.GetCategorizationForEachWayPoint(null));
        }
    }
}
