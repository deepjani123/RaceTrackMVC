using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RaceTrackMVC.Models
{
    public class TrackDBContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<VehicleTrack> VehicleTracks { get; set; }

    }
}