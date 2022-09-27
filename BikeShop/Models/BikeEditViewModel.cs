using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeShop.Models
{
    public class BikeEditViewModel
    {
        [DisplayName("Manufacturer")]
        [Required, MaxLength(25)]
        public string Manufacturer { get; set; }

        [DisplayName("Model")]
        [Required, MaxLength(50)]
        public string Model { get; set; }

        [DisplayName("Type")]
        [Required, MaxLength(25)]
        public string Type { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem("Roadbike","Roadbike"),
            new SelectListItem("Mountainbike","MountainBike"),
            new SelectListItem("Cross Country", "Cross Country"),
            new SelectListItem("Enduro AM","Enduro AM"),
            new SelectListItem("Downhill","Downhill"),
            new SelectListItem("Freeride MTB","Freeride MTB"),
            new SelectListItem("Gravelbike", "Gravelbike")
        };

        [DisplayName("Year")]
        [Required]
        public int Year { get; set; }

        [DisplayName("Price")]
        [Required]
        public double Price { get; set; }

        [DisplayName("Photo")]
        public IFormFile Photo { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
