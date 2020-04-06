using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext(DbContextOptions<ZooDbContext> optionsBuilder) : base(optionsBuilder)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public ZooDbContext()
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Food> Food { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=localhost;Database=ZooDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var lion = new Animal
            {
                AnimalType = "Mammal",
                BirthDate = DateTime.Now.AddDays(-1),
                FedToTime = DateTime.Now.AddHours(2),
                FoodType = "Meat",
                Name = "Alex",
                Weight = 8000,
                Id = 1
            };

            var bird = new Animal
            {
                AnimalType = "Bird",
                BirthDate = DateTime.Now.AddDays(-3),
                FedToTime = DateTime.Now,
                FoodType = "Corn",
                Name = "Red",
                Weight = 84,
                Id = 2
            };

            var fish = new Animal
            {
                AnimalType = "Fish",
                BirthDate = DateTime.Now.AddDays(-3),
                FedToTime = DateTime.Now.AddHours(-1),
                FoodType = "Fish feed",
                Name = "Nemo",
                Weight = 42,
                Id = 3
            };

            var meatStorage = new Food
            {
                AssimilationMultiplierCoefficient = 6,
                Calorific = 30000,
                FoodType = "Meat",
                Name = "15 kg of meat",
                Quantity = 500,
                Id = 1
            };

            var cornStorage = new Food
            {
                AssimilationMultiplierCoefficient = 2,
                Calorific = 2000,
                FoodType = "Corn",
                Name = "1 kg of corn",
                Quantity = 100,
                Id = 2
            };

            var fishFeedStorage = new Food
            {
                AssimilationMultiplierCoefficient = 3,
                Calorific = 1000,
                FoodType = "Fish feed",
                Name = "1 kg of fish corn",
                Quantity = 50,
                Id = 3
            };

            modelBuilder.Entity<Animal>().HasData(lion, bird, fish);
            modelBuilder.Entity<Food>().HasData(meatStorage, cornStorage, fishFeedStorage);
        }
    }
}