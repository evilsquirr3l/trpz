using AutoMapper;
using Business.Abstract;
using Business.Realization.MapperProfile;
using Business.Realization.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Realization
{
    public static class DllBinder
    {
        public static IServiceCollection BindBll(this IServiceCollection services)
        {
            services.AddSingleton<IAnimalService, AnimalService>();
            services.AddSingleton<IFoodService, FoodService>();
            services.AddSingleton<ITimeService, TimeService>();

            var mapperConfig = new MapperConfiguration(c => c.AddProfile(new AutoMapperProfile()));

            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
            
            return services;
        }
    }
}