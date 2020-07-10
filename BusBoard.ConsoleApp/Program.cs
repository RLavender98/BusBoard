using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BusBoard.Api;

namespace BusBoard.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
      
      Console.WriteLine("Please enter your postcode:");
      string postcode = Console.ReadLine();
      var postcodeObject = new Coordinate();

      var coordinateGetter = new CoordinateGetter();
      postcodeObject.Coordinates = coordinateGetter.GetCoordinate(postcode);
      
      List<BusStop> BusStops = postcodeObject.getBusStops(postcodeObject.Coordinates);
      foreach (var busStop in BusStops.Take(2))
      {
        Console.WriteLine(busStop.CommonName);
        var busGetter = new BusGetter();
        busStop.ArrivingBuses = busGetter.GetBuses(busStop.NaptanId);
        foreach (var bus in busStop.ArrivingBuses)
        {
          Console.WriteLine($"{bus.LineId}, {bus.DestinationName}, {bus.TimeToStation}");
        }
      }
    }
  }
}
