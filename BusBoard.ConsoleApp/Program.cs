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

      string busStopId = Console.ReadLine();

      var client = new RestClient("https://api.tfl.gov.uk/");
      client.Authenticator = new SimpleAuthenticator("app_id","aa8ba038","app_key","bd6097d64168d6f16399d1e87c2847dc");

      var request = new RestRequest($"StopPoint/{busStopId}/Arrivals", DataFormat.Json);
      var response = client.Get(request);
      string responseBuses = response.Content;
      var infoBus = JsonConvert.DeserializeObject<List<Bus>>(responseBuses);

      foreach (var bus in infoBus.Take(5))
      {
        Console.WriteLine($"{bus.lineId}, {bus.destinationName}, {bus.timeToStation}");
      }
    }
  }

  public class Bus
  {
    public int lineId;
    public string destinationName;
    public int timeToStation;
  }
}
