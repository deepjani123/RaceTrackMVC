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
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult GetVehicles()
        {
            return Json(new { data = _trackDBContext.Vehicles.ToList() }, JsonRequestBehavior.AllowGet);

            
        }

        [HttpPost]
        public ActionResult AddVehicle(Vehicle vehicle)
        {
            if (vehicle.Type == null)
                return View();


            Vehicle = vehicle;


            Vehicle.Type = Enum.GetName(typeof(VehicleType), Convert.ToInt32(Vehicle.Type));
            _trackDBContext.Vehicles.Add(Vehicle);
            _trackDBContext.SaveChanges();

            //to clear previous form data
            ModelState.Clear();
            return View("Index");
        }
    }
}