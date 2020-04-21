using AutoMapper;
using Entities;
using Models;

namespace Business.Implementation.MapperProfile
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