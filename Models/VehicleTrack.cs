using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceTrackMVC.Models
{
    public class VehicleTrack
    {
        public Vehicle Vehicle { get; set; }

        public Track Track { get; set; }

        [Key, Column(Order =1)]
        public int TrackId { get; set; }
        
        [Key, Column(Order = 2)]
        public int VehicleId { get; set; }
    }
}