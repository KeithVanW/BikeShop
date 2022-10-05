using System.ComponentModel.DataAnnotations;

namespace BikeShop.Domain.Cart
{
    public class Item
    {
        public int ItemId { get; set; }

        public int Quantity { get; set; }

        [Required]
        public virtual Bike Bike { get; set; }

        public Bag Bag { get; set; }
    }
}
