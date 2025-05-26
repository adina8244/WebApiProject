using AutoMapper;
using DTO;
using Entites;
using System.Runtime.CompilerServices;

namespace DisneyShop
{
    public class MappingProfile : Profile
    {
      
        public MappingProfile() 
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Proudct, ProudctDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<UserLogin, UserLoginDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();



        }
    }
}
