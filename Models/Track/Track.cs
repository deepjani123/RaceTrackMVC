using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace RaceTrackMVC.Models
{
    public class Track
    {

        public Track()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}