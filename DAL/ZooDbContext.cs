using System;
using System.Collections.Generic;
using DAL.Models;
using DAL.Types;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext(DbContextOptions<ZooDbContext> optionsBuilder) : base(optionsBuilder)
        {
            Database.EnsureCreated();
        }

        public ZooDbContext()
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            optionsBuilder.UseSqlServer("Server=localhost;Database=Zoo;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            var meat = new FoodType() {TypeOfFood = "Meat"};
            var corn = new FoodType() {TypeOfFood = "Corn"};
            var fishFeed = new FoodType() { TypeOfFood = "Fish feed"};
            
            var lion = new Animal()
            {
                AnimalType = AnimalType.Mammals,
                BirthDate = DateTime.Now.AddDays(-1),
                FedToTime = DateTime.Now.AddHours(2),
                FoodTypes = new List<FoodType>() { meat },
                Name = "Alex",
                Weight = 190
            };
            
            var bird = new Animal()
            {
                AnimalType = AnimalType.Bird,
                BirthDate = DateTime.Now.AddDays(-3),
                FedToTime = DateTime.Now,
                FoodTypes = new List<FoodType>() { corn },
                Name = "Red",
                Weight = 2
            };
            
            var fish = new Animal()
            {
                AnimalType = AnimalType.Fish,
                BirthDate = DateTime.Now.AddDays(-3),
                FedToTime = DateTime.Now.AddHours(-1),
                FoodTypes = new List<FoodType>() { corn, fishFeed },
                Name = "Nemo",
                Weight = 1
            };
            
            var meatStorage = new Food()
            {
                AssimilationMultiplierCoefficient = 1,
                Calorific = 3000,
                FoodType = meat,
                Name = "Piece of meat",
                Quantity = 500
            };
            
            var cornStorage = new Food()
            {
                
            };
            
            modelBuilder.Entity<Animal>().HasData(lion, bird, fish);
            modelBuilder.Entity<FoodType>().HasData(meat, corn, fishFeed);
        }
    }
}