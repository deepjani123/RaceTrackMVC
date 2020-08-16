using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RaceTrackMVC.Models
{
    public class Vehicle
    {

        public Vehicle()
        {
            this.Tracks = new HashSet<Track>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        [Range(0,5)]
        public int Lift { get; set; }

        [Range(0,85)]
        public int TireWear { get; set; }

        public bool IsTrue => true;

        [Required]
        [Display(Name = "Tow Strap")]
        [System.ComponentModel.DataAnnotations.Compare(nameof(IsTrue), ErrorMessage = "Vehicle must have tow strap")]
        public bool HasTowStrap { get; set; }


        public virtual ICollection<Track> Tracks { get; set; }

    }

    public enum VehicleType
    {
        Car,
        Truck
    }
}