using System;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    public class Result
    {
        public float longitude;
        public float latitude;
    }

    public class WeirdResult
    {
        public Result result;
    }
    public class GetsCoordinates
    {
        public Result Result;
        public string Postcode;

        public GetsCoordinates()
        {
            Console.WriteLine("Please enter your postcode:");
            Postcode = Console.ReadLine();
            
            var client = new RestClient("http://api.postcodes.io/");
            var request = new RestRequest($"postcodes/{Postcode}", DataFormat.Json);
            var response = client.Get(request);
            string responsePostcode = response.Content;
            var info = JsonConvert.DeserializeObject<WeirdResult>(responsePostcode);
            Result = info.result;
        }

        public list<BusStop> getBusStops(Result coordinate)
        {
            var client = new RestClient("https://api.tfl.gov.uk/");
            client.Authenticator =
                new SimpleAuthenticator("app_id", "aa8ba038", "app_key", "bd6097d64168d6f16399d1e87c2847dc");

            var request = new RestRequest($"StopPoint?stopTypes=NaptanPublicBusCoachTram&modes=bus&lat={coordinate.latitude}&lon={coordinate.longitude}", DataFormat.Json);
            
            var response = client.Get(request);
            string responseBusStops = response.Content;
            var infoBusStops = JsonConvert.DeserializeObject<List<BusStop>>(responseBusStops);
            return infoBusStops;
        }
    }
}