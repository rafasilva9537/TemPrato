using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipesApi.Models;

namespace RecipesApi.Data;

public class NutrientConfiguration : IEntityTypeConfiguration<Nutrient>
{
    public void Configure(EntityTypeBuilder<Nutrient> builder)
    {
        builder.ToTable("Nutrient");
        builder.HasKey(n => n.Id);

        builder.Property(n => n.Name).HasMaxLength(70);
        
        builder.HasOne(n => n.UnitOfMeasurement)
            .WithMany(uom => uom.Nutrients).
            HasForeignKey(n => n.Unit);
    }
}