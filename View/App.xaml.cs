using System;
using System.Configuration;
using System.Windows;
using BLL.Interfaces;
using BLL.MapperProfile;
using BLL.Services;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ViewModel;

namespace View
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var service = new ServiceCollection();
            ConfigureServices(service);

            ServiceProvider = service.BuildServiceProvider();
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            serviceCollection.BuildServiceProvider();

            var viewModel = new MainWindowViewModel(ServiceProvider.GetService<ITimeService>(),
                ServiceProvider.GetService<IAnimalService>(), ServiceProvider.GetService<IFoodService>());

            var mainWindow = new MainWindow {DataContext = viewModel};

            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ZooDbContext>(opt =>
                opt.UseSqlServer(ConfigurationManager.ConnectionStrings["Zoo"].ConnectionString));
            services.AddTransient(typeof(MainWindow));
            services.AddTransient<IAnimalRepository, AnimalRepository>();
            services.AddTransient<IFoodRepository, FoodRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddMapper();
            services.AddSingleton<ITimeService, TimeService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IAnimalService, AnimalService>();
        }
    }
}