﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Migrations
{
    [DbContext(typeof(ZooDbContext))]
    partial class ZooDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnimalType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FedToTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FoodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnimalType = "Mammals",
                            BirthDate = new DateTime(2020, 3, 28, 20, 57, 25, 969, DateTimeKind.Local).AddTicks(8650),
                            FedToTime = new DateTime(2020, 3, 29, 22, 57, 25, 972, DateTimeKind.Local).AddTicks(7950),
                            FoodType = "Meat",
                            Name = "Alex",
                            Weight = 190
                        },
                        new
                        {
                            Id = 2,
                            AnimalType = "Bird",
                            BirthDate = new DateTime(2020, 3, 26, 20, 57, 25, 972, DateTimeKind.Local).AddTicks(9532),
                            FedToTime = new DateTime(2020, 3, 29, 20, 57, 25, 972, DateTimeKind.Local).AddTicks(9559),
                            FoodType = "Corn",
                            Name = "Red",
                            Weight = 2
                        },
                        new
                        {
                            Id = 3,
                            AnimalType = "Fish",
                            BirthDate = new DateTime(2020, 3, 26, 20, 57, 25, 972, DateTimeKind.Local).AddTicks(9605),
                            FedToTime = new DateTime(2020, 3, 29, 19, 57, 25, 972, DateTimeKind.Local).AddTicks(9610),
                            FoodType = "Fish feed",
                            Name = "Nemo",
                            Weight = 1
                        });
                });

            modelBuilder.Entity("DAL.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssimilationMultiplierCoefficient")
                        .HasColumnType("int");

                    b.Property<int>("Calorific")
                        .HasColumnType("int");

                    b.Property<string>("FoodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FoodTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Food");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssimilationMultiplierCoefficient = 1,
                            Calorific = 3000,
                            FoodType = "Meat",
                            FoodTypeId = 0,
                            Name = "5 kg of meat",
                            Quantity = 500
                        },
                        new
                        {
                            Id = 2,
                            AssimilationMultiplierCoefficient = 2,
                            Calorific = 2000,
                            FoodType = "Corn",
                            FoodTypeId = 0,
                            Name = "1 kg of corn",
                            Quantity = 100
                        },
                        new
                        {
                            Id = 3,
                            AssimilationMultiplierCoefficient = 3,
                            Calorific = 1000,
                            FoodType = "Fish feed",
                            FoodTypeId = 0,
                            Name = "1 kg of fish corn",
                            Quantity = 50
                        });
                });

            modelBuilder.Entity("DAL.Models.FoodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeOfFood")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FoodTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
