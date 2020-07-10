using System.Collections.Generic;
using System.Web.Mvc;
using BusBoard.Api;
using BusBoard.Web.Models;
using BusBoard.Web.ViewModels;

namespace BusBoard.Web.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public ActionResult BusInfo(PostcodeSelection selection)
    {
      // Add some properties to the BusInfo view model with the data you want to render on the page.
      // Write code here to populate the view model with info from the APIs.
      var postcodeObject = new Coordinate();
      
      var coordinateGetter = new CoordinateGetter();
      postcodeObject.Coordinates = coordinateGetter.GetCoordinate(selection.Postcode);

      List<BusStop> BusStops = postcodeObject.getBusStops(postcodeObject.Coordinates);
      var nearestStops = BusStops.GetRange(0,2);
      foreach (var busStop in nearestStops)
      {
        var busGetter = new BusGetter();
        busStop.ArrivingBuses = busGetter.GetBuses(busStop.NaptanId);
      }
      
      // Then modify the view (in Views/Home/BusInfo.cshtml) to render upcoming buses.
      var info = new BusInfo(selection.Postcode, nearestStops);
      return View(info);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Information about this site";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Contact us!";

      return View();
    }
  }
}