using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipesApi.Models;

namespace RecipesApi.Data;

public class UnitOfMeasurementConfiguration : IEntityTypeConfiguration<UnitOfMeasurement>
{
    public void Configure(EntityTypeBuilder<UnitOfMeasurement> builder)
    {
        builder.ToTable("UnitOfMeasurement");
        builder.HasKey(uom => uom.Name);

        builder.Property(uom => uom.Name).HasMaxLength(50);
    }
}