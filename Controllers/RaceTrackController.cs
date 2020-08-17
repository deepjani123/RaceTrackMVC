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

        public VehicleTrack VehicleTrack { get; set; }

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


        [HttpPost]
        public ActionResult AddToTrack(int? VehicleId)
        {
            VehicleTrack = new VehicleTrack();

            int total = _trackDBContext.VehicleTracks.Count();

            if(total>=5)
            {
                return Json(new { success = false, message = "race track is full!" });
            }

            var vehicle = _trackDBContext.VehicleTracks.FirstOrDefault(u => u.VehicleId == VehicleId);

            if(vehicle!=null)
            {
                return Json(new { success = false, message = "this vehicle is already on track!" });
            }
            else
            {
                VehicleTrack.VehicleId = (int)VehicleId;
                VehicleTrack.TrackId = 1;
                _trackDBContext.VehicleTracks.Add(VehicleTrack);
                _trackDBContext.SaveChanges();
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult GetVehicleOnTrack()
        {

            string trackName = (from t in _trackDBContext.Tracks where t.Id == 1 select t.Name).FirstOrDefault();
            var query = from vt in _trackDBContext.VehicleTracks
                        from t in _trackDBContext.Tracks
                        select new
                        {
                            vehicleId = vt.VehicleId,
                            vehicleName = vt.Vehicle.Name,
                            trackName = trackName
                        };

            

            return Json(new { data = query.ToList() }, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public ActionResult RemoveFromTrack(int? VehicleId)
        {
            

            VehicleTrack = _trackDBContext.VehicleTracks.FirstOrDefault(u => u.VehicleId == VehicleId);

            if (VehicleTrack == null)
            {
                return Json(new { success = false, message = "vehicle not found!" });
            }
            else
            {
                _trackDBContext.VehicleTracks.Remove(VehicleTrack);
                _trackDBContext.SaveChanges();
            }

            return Json(new { success = false, message = "Removed from track!" });

        }
    }
}