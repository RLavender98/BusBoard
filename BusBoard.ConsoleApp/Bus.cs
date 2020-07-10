using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard.ConsoleApp
{
    public class Bus
    {
        public int lineId;
        public string destinationName;
        public int timeToStation;
    }
}