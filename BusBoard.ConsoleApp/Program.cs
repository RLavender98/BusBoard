using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;


namespace BusBoard.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

      var postcode = new GetsCoordinates();

      //var busStop = new BusStop();
      //busStop.GetBuses();
      List<BusStop> BusStops = postcode.getBusStops(postcode.Result);
      foreach (var busStop in BusStops.Take(2))
      {
        Console.WriteLine(busStop.commonName);
        busStop.GetBuses();
      }
    }
  }
}
