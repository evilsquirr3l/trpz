using Dal.Abstract;
using DAL.Realization.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Realization
{
    public static class DalBinder
    {
        public static IServiceCollection BindDal(this IServiceCollection services)
        {
            services.AddSingleton<IAnimalRepository, AnimalRepository>();
            services.AddSingleton<IFoodRepository, FoodRepository>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}