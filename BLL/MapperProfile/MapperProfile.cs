using AutoMapper;
using BLL.Models;
using DAL;

namespace BLL.MapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Animal, AnimalModel>().ReverseMap();
        }
    }
}