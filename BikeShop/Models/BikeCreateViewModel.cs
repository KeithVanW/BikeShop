using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BikeShop.Models
{
    public class BikeCreateViewModel
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

        [DisplayName("Year")]
        [Required]
        public int Year { get; set; }

        [DisplayName("Price")]
        [Required]
        public double Price { get; set; }

        [DisplayName("Photo")]
        public IFormFile Photo { get; set; }
    }
}
