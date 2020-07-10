using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BusBoard;
using System.Text;
using System.Threading.Tasks;
using BusBoard.Api;
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
      
      Console.WriteLine("Please enter your postcode:");
      string postcode = Console.ReadLine();
      var postcodeObject = new GetsCoordinates(postcode);
      
      List<BusStop> BusStops = postcodeObject.getBusStops(postcodeObject.Result);
      foreach (var busStop in BusStops.Take(2))
      {
        Console.WriteLine(busStop.commonName);
        busStop.GetBuses();
      }
    }
  }
}
