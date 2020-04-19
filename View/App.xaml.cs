﻿using System;
using System.Configuration;
using System.Windows;
using BLL.Interfaces;
using BLL.MapperProfile;
using BLL.Services;
using DAL.Realization;
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
            
            DisplayRootRegistry.RegisterWindowType<MainWindowViewModel, MainWindow>();
            DisplayRootRegistry.RegisterWindowType<AddAnimalVM, AddAnimalWindow>();
            DisplayRootRegistry.RegisterWindowType<AddFoodVM, AddFoodWindow>();
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        public DisplayRootRegistry DisplayRootRegistry { get; } = new DisplayRootRegistry();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            serviceCollection.BuildServiceProvider();
            
            var animalCommand = new OpenAddAnimalWindowCommand(){AnimalService = ServiceProvider.GetService<IAnimalService>()};
            var foodCommand = new OpenAddFoodWindowCommand(){FoodService = ServiceProvider.GetService<IFoodService>()};
            var viewModel = new MainWindowViewModel(ServiceProvider.GetService<ITimeService>(),
                ServiceProvider.GetService<IAnimalService>(), ServiceProvider.GetService<IFoodService>(), animalCommand, foodCommand);


            DisplayRootRegistry.ShowModalPresentation(viewModel);
            Shutdown();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ZooDbContext>(opt =>
                opt.UseSqlServer(ConfigurationManager.ConnectionStrings["Zoo"].ConnectionString));
            services.AddTransient(typeof(MainWindow));
            services.BindDal();
            services.AddMapper();
            services.AddSingleton<ITimeService, TimeService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IAnimalService, AnimalService>();
        }
        
        //TODO: binary serializer, project with file, fix use-case, divide interfaces and implementation, installer for each proj, separate models and entities, add CRUD operations 
    }
    //1. add crud
    //2. serializer
    //3. window
    //4. divide to separete projects
    //5. use-case diagram
    
    //attribute model
}