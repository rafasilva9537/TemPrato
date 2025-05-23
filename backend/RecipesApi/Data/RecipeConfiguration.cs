using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipesApi.Models;

namespace RecipesApi.Data;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.ToTable("Recipe");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name).HasMaxLength(100);
        builder.Property(r => r.Description).HasMaxLength(300);
        builder.Property(r => r.Text).HasMaxLength(4000);

        builder.HasMany(r => r.Nutrients)
            .WithMany(n => n.Recipes)
            .UsingEntity<RecipeNutrient>();

        builder.HasMany(r => r.Tags)
            .WithMany(t => t.Recipes)
            .UsingEntity<RecipeTag>();
    }
}