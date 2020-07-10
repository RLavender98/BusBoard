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
      Console.WriteLine(postcode.Result.latitude);
      Console.WriteLine(postcode.Result.longitude);
      
      //var busStop = new BusStop();
      //busStop.GetBuses();
      list<BusStop> BusStops = postcode.getBusStops(postcode.Result);
    }
  }
}
