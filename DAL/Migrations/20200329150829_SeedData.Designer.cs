﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ZooDbContext))]
    [Migration("20200329150829_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("DAL.Models.AnimalFoodType", b =>
                {
                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("FoodTypeId")
                        .HasColumnType("int");

                    b.HasKey("AnimalId", "FoodTypeId");

                    b.HasIndex("FoodTypeId");

                    b.ToTable("AnimalFoodType");

                    b.HasData(
                        new
                        {
                            AnimalId = 1,
                            FoodTypeId = 1
                        },
                        new
                        {
                            AnimalId = 2,
                            FoodTypeId = 2
                        },
                        new
                        {
                            AnimalId = 3,
                            FoodTypeId = 3
                        },
                        new
                        {
                            AnimalId = 3,
                            FoodTypeId = 2
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

                    b.Property<int>("FoodTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodTypeId");

                    b.ToTable("Food");
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TypeOfFood = "Meat"
                        },
                        new
                        {
                            Id = 2,
                            TypeOfFood = "Corn"
                        },
                        new
                        {
                            Id = 3,
                            TypeOfFood = "Fish feed"
                        });
                });

            modelBuilder.Entity("DAL.Models.AnimalFoodType", b =>
                {
                    b.HasOne("DAL.Models.Animal", "Animal")
                        .WithMany("FoodTypes")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.FoodType", "FoodType")
                        .WithMany("Animals")
                        .HasForeignKey("FoodTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.Food", b =>
                {
                    b.HasOne("DAL.Models.FoodType", "FoodType")
                        .WithMany()
                        .HasForeignKey("FoodTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}