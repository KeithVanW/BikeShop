using System.ComponentModel.DataAnnotations;

namespace BikeShop.Domain.Cart
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public ICollection<Bag> Bags { get; set; }
    }
}
