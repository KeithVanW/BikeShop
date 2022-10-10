using AutoMapper;
using BikeShop.Domain;
using BikeShop.Domain.Cart;
using BikeShop.Models;
using BikeShop.Models.Customer;

namespace BikeShop.Profiles
{
    public class BikeProfile : Profile
    {
        public BikeProfile()
        {
            CreateMap<Bike, BikeListViewModel>();
            CreateMap<Bike, BikeCreateViewModel>().ReverseMap();
            CreateMap<Bike, BikeDetailViewModel>();
            CreateMap<Bike, BikeEditViewModel>().ReverseMap();
            CreateMap<Bike, BikeDeleteViewModel>();

            CreateMap<Customer, CustomerListViewModel>();
            CreateMap<Customer, CustomerCreateViewModel>().ReverseMap();
            CreateMap<Customer, CustomerDetailViewModel>();
            CreateMap<Customer, CustomerEditViewModel>().ReverseMap();
            CreateMap<Customer, CustomerDeleteViewModel>();
        }
    }
}