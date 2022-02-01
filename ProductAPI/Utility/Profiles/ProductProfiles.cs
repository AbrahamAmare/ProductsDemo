using AutoMapper;
using ProductAPI.Data.DTO.Products;
using ProductAPI.Data.Models;

namespace ProductAPI.Utility.Profiles
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<Product, ProductRequest>().ReverseMap();
        }
    }
}
