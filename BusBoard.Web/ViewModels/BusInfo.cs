using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.Web.ViewModels
{
  public class BusInfo
  {
    public BusInfo(string postCode, List<BusStop> nearestStops)
    {
      PostCode = postCode;
      NearestStops = nearestStops;
    }
    
    public string PostCode { get; set; }
    public List<BusStop> NearestStops;

  }
}