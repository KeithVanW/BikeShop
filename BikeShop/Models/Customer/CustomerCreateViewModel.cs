using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BikeShop.Models.Customer
{
    public class CustomerCreateViewModel
    {
        [DisplayName("First name")]
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required, MaxLength(50)]
        public string LastName { get; set; }
    }
}