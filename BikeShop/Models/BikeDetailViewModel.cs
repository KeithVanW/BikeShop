using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BikeShop.Models
{
    public class BikeDetailViewModel
    {
        [DisplayName("Manufacturer")]
        public string Manufacturer { get; set; }

        [DisplayName("Model")]
        public string Model { get; set; }

        [DisplayName("Type")]
        public string Type { get; set; }

        [DisplayName("Year")]
        public int Year { get; set; }

        [DisplayName("Price")]
        public double Price { get; set; }

        [DisplayName("Photo")]
        public string PhotoUrl { get; set; }
    }
}
