using System;
using System.Windows;
using BLL.Interfaces;
using BLL.MapperProfile;
using BLL.Services;
using DAL;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace View
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

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
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ZooDbContext>(opt =>
                opt.UseSqlServer("Server=localhost;Database=Zoo;Trusted_Connection=True;"));
            services.AddTransient(typeof(MainWindow));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMapper();
            services.AddTransient<IAnimalService, AnimalService>();
            services.AddTransient<ITimeService, TimeService>();
        }
    }
}