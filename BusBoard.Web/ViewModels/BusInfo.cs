using System.Collections.Generic;
using System.Web.Services.Description;
using BusBoard.Api;

namespace BusBoard.Web.ViewModels
{
  public class BusInfo
  {
    //CONSTRUCTOR HERE:
    public BusInfo(string postCode)
    {
      PostCode = postCode;
      
      var postcodeObject = new GetsCoordinates(PostCode);
      
      List<BusStop> BusStops = postcodeObject.getBusStops(postcodeObject.Result);
      var nearestStops = BusStops.GetRange(0,2);
      foreach (var busStop in nearestStops)
      {
        busStop.GetBuses();
      }

      NearestStops = nearestStops;
    }
    //PROPERTIES HERE:
    public string PostCode { get; set; }
    public List<BusStop> NearestStops;

  }
}