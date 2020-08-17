using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace RaceTrackMVC.Models
{
    public class Track
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<VehicleTrack> VehicleTracks { get; set; }
    }
}