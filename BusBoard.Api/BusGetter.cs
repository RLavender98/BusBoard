using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard.Api
{
    public class BusGetter
    {
        public List<Bus> GetBuses(string naptanId)
        {
            var client = new RestClient("https://api.tfl.gov.uk/");
            client.Authenticator =
                new SimpleAuthenticator("app_id", "aa8ba038", "app_key", "bd6097d64168d6f16399d1e87c2847dc");

            var request = new RestRequest($"StopPoint/{naptanId}/Arrivals", DataFormat.Json);
            var response = client.Get(request);
            string responseBuses = response.Content;
            var infoBus = JsonConvert.DeserializeObject<List<Bus>>(responseBuses);

            return infoBus.GetRange(0, 5);
        }
    }
}