using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RaceTrackMVC.Models
{
    public class TrackDBContext : DbContext
    {
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        public virtual DbSet<Track> Tracks { get; set; }

        public virtual DbSet<VehicleTrack> VehicleTracks { get; set; }

    }
}