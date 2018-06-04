using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeExamples.Models;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace CodeExamples.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET:  Location/ViewAllLocations
        public IActionResult ViewAllLocations(int selectedCustomerID, int userID)
        {
            LocationModel model = new LocationModel();
            List<Location> locations = Location.GetAllLocations(selectedCustomerID, userID);

            if (locations != null)
            {
                model.Locations = locations;
            }

            return View(model);
        }

        public IActionResult GetLocationByID(int? locationID, int selectedCustomerID, int userID)
        {
            var location = Location.GetAllLocations(selectedCustomerID, userID).
                Where(x => x.LocationID == locationID);

            if (location != null)
            {
                LocationModel model = new Models.LocationModel();

                foreach (var item in location)
                {
                    model.LocationName = item.LocationName;
                    model.FullAddress = item.FullAddress;
                    model.ParentLocationName = item.ParentLocationName;
                }

                return View(model);
            }

            return View(); //Should never reach this
        }

    }
}