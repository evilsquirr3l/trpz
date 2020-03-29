using System;
using System.Windows;
using BLL.Interfaces;
using BLL.MapperProfile;
using BLL.Services;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WpfLibrary;

namespace View
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            var service = new ServiceCollection();
            ConfigureServices(service);

            ServiceProvider = service.BuildServiceProvider();
        }
        
        /*public IConfiguration Configuration { get; private set; }*/

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            /*
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
 
            Configuration = builder.Build();
            */

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            
            serviceCollection.BuildServiceProvider();
            
            var viewModel = new MainWindowViewModel(ServiceProvider.GetService<ITimeService>(), ServiceProvider.GetService<IAnimalService>());
            
            var mainWindow = new MainWindow(){DataContext = viewModel};
            
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ZooDbContext>(opt =>
                opt.UseSqlServer("Server=localhost;Database=Zoo2;Trusted_Connection=True;"));
            services.AddTransient(typeof(MainWindow));
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            //services.AddScoped<IRepository<Food>, Repository<Food>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMapper();
            services.AddTransient<IAnimalService, AnimalService>();
            services.AddTransient<ITimeService, TimeService>();
        }
    }
}