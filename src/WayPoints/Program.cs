using System;
using System.Collections.Generic;
using System.Linq;
namespace WayPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            bool success = false;
            while (!success)
            {
                try
                {
                    Console.Write("File path: ");
                    var filePath = Console.ReadLine();
                    if (System.IO.File.Exists(filePath))
                    {
                        var wayPoints = ParseFileToWayPoints(filePath);
                        if (!wayPoints.Any())
                        {
                            Console.WriteLine("No way points in file");
                        }
                        var wayPointsCategorizations = WayPointsCategorizationApi.GetCategorizationForEachWayPoint(wayPoints);
                        Console.WriteLine("Way point\tDistance speeding\tDuration speeding\tTotal distance\tTotal duration");
                        int i = 0;
                        foreach (var wayPoint in wayPointsCategorizations)
                        {
                            Console.WriteLine(i++ + "\t"
                                + wayPoint.DistanceSpeeding + "\t"
                                + wayPoint.DurationSpeeding + "\t"
                                + wayPoint.TotalDistance + "\t"
                                + wayPoint.TotalDuration);
                        }
                    }
                    else
                    {
                        Console.WriteLine("File not found");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Parsing fail: " + e.Message);
                    Console.WriteLine("Try again");
                } 
            }
        }

        private static IEnumerable<WayPoint> ParseFileToWayPoints(string filePath)
        {
            var json = System.IO.File.ReadAllText(filePath);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<WayPoint>>(json);
        }
    }

}
