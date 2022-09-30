using AutoMapper;
using BikeShop.Domain;
using BikeShop.Models;
using BikeShop.Models.Shop;

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
            CreateMap<Bike, ShopDetailViewModel>();
            CreateMap<Bike, ShopListItem>();
            CreateMap<Bike, BikeDeleteViewModel>();
        }
    }
}