using AutoMapper;
using BLL.Models;
using Entities;

namespace Business.Realization.MapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Animal, AnimalModel>()
                .ReverseMap();

            CreateMap<Food, FoodModel>().ReverseMap();
        }
    }
}