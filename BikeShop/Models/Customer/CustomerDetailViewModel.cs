using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BikeShop.Models.Customer
{
    public class CustomerDetailViewModel
    {
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
    }
}
