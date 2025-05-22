using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipesApi.Models;

namespace RecipesApi.Data;

public class RecipeNutrientConfiguration : IEntityTypeConfiguration<RecipeNutrient>
{
    public void Configure(EntityTypeBuilder<RecipeNutrient> builder)
    {
        builder.ToTable("RecipeNutrient");
        builder.HasKey(rn => new { rn.RecipeId, rn.NutrientId });
    }
}
