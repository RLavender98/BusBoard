using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.Api
{
    public class CoordinateGetter
    {
        public JsonPostcodeCoordinate GetCoordinate(string postcode)
        {
            var client = new RestClient("http://api.postcodes.io/");
            var request = new RestRequest($"postcodes/{postcode}", DataFormat.Json);
            var response = client.Get(request);
            string responsePostcode = response.Content;
            var info = JsonConvert.DeserializeObject<JsonPostcodeResult>(responsePostcode);
            return info.Result;
        }
    }
}