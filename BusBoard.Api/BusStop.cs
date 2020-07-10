using System.Collections.Generic;

namespace BusBoard.Api
{
    public class BusStop
    {
        public string NaptanId{ get; set; }
        public string CommonName{ get; set; }
        public List<Bus> ArrivingBuses{ get; set; }
        
    }
}