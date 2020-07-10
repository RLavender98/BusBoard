using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard.Api
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

        public GetsCoordinates(string postcode)
        {
            Postcode = postcode;
            
            var client = new RestClient("http://api.postcodes.io/");
            var request = new RestRequest($"postcodes/{Postcode}", DataFormat.Json);
            var response = client.Get(request);
            string responsePostcode = response.Content;
            var info = JsonConvert.DeserializeObject<WeirdResult>(responsePostcode);
            Result = info.result;
        }

        public List<BusStop> getBusStops(Result coordinate)
        {
            var client = new RestClient("https://api.tfl.gov.uk/");
            client.Authenticator =
                new SimpleAuthenticator("app_id", "aa8ba038", "app_key", "bd6097d64168d6f16399d1e87c2847dc");

            var request = new RestRequest($"StopPoint?stopTypes=NaptanPublicBusCoachTram&modes=bus&lat={coordinate.latitude}&lon={coordinate.longitude}", DataFormat.Json);
            
            var response = client.Get(request);
            string responseBusStops = response.Content;
            var infoBusStops = JsonConvert.DeserializeObject<StopPoints>(responseBusStops);
            return infoBusStops.stopPoints;
        }
        
        public class StopPoints
        {
            public List<BusStop> stopPoints;
        }
    }
}