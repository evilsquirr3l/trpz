using System;
using DAL.Models;
using DAL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.ModelConfigurations
{
    public class FoodConfig : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder
                .Property(f => f.FoodType)
                .HasConversion(type => type.ToString(),
                    v => (FoodType) Enum.Parse(typeof(FoodType), v));
        }
    }
}