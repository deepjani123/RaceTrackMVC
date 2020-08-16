using RaceTrackMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RaceTrackMVC.Controllers
{
    public class RaceTrackController : Controller
    {
        private readonly TrackDBContext _trackDBContext;

        
        public Vehicle Vehicle { get; set; }

        public RaceTrackController(TrackDBContext trackDBContext)
        {
            _trackDBContext = trackDBContext;
        }

        // GET: RaceTrack
        public ActionResult Index(Vehicle vehicle)
        {
            if (vehicle.Type==null)
                return View();

            Vehicle = vehicle;

            //if (vehicle.Count == 0)
            //    return View();
            //else
            //{
            //    Vehicle.Type = Enum.GetName(typeof(VehicleType),Convert.ToInt32(vehicle["Type"].ToString()));
            //}

            //Vehicle.Name = vehicle["Name"].ToString();
            //if(Vehicle.Type=="Truck")
            //{
            //    Vehicle.Lift = Convert.ToInt32(vehicle["Lift"].ToString());
            //    Vehicle.TireWear = 0;

            //}
            //else
            //{
            //    Vehicle.Lift = 0;
            //    Vehicle.TireWear = Convert.ToInt32(vehicle["Tirewear"].ToString());
            //}


            
            _trackDBContext.Vehicles.Add(Vehicle);
            _trackDBContext.SaveChanges();
            return View();
        }
    }
}