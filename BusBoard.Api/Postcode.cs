using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard.Api
{
    public class JsonPostcodeCoordinate
    {
        public float Longitude { get; set; }
        public float Latitude  { get; set; }
    }

    public class JsonPostcodeResult
    {
        public JsonPostcodeCoordinate Result{ get; set; }
    }

    public class Coordinate
    {
        public JsonPostcodeCoordinate Coordinates{ get; set; }
        public string Postcode{ get; set; }
     
        public List<BusStop> getBusStops(JsonPostcodeCoordinate coordinate)
        {
            var client = new RestClient("https://api.tfl.gov.uk/");
            client.Authenticator =
                new SimpleAuthenticator("app_id", "aa8ba038", "app_key", "bd6097d64168d6f16399d1e87c2847dc");

            var request =
                new RestRequest(
                    $"StopPoint?stopTypes=NaptanPublicBusCoachTram&modes=bus&lat={coordinate.Latitude}&lon={coordinate.Longitude}",
                    DataFormat.Json);

            var response = client.Get(request);
            string responseBusStops = response.Content;
            var infoBusStops = JsonConvert.DeserializeObject<StopPoints>(responseBusStops);
            return infoBusStops.stopPoints;
        }
    }
    public class StopPoints
    {
        public List<BusStop> stopPoints;
    }
}