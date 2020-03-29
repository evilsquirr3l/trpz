using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.ModelConfigurations
{
    public class AnimalConfig : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder
                .Property(a => a.AnimalType)
                .HasConversion(type => type.ToString(),
                    v => (AnimalType) Enum.Parse(typeof(AnimalType), v));
            
        }
    }
}