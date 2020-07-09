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
            // infoPostcode.result.longitude;
        }
    }
}