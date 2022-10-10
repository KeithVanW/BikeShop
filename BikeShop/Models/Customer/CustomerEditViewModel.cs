﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BikeShop.Models.Customer
{
    public class CustomerEditViewModel
    {
        public string Title { get; } = "Edit Customer";

        [DisplayName("First name")]
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required, MaxLength(50)]
        public string LastName { get; set; }
    }
}