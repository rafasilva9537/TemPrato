using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RecipesApi.Models;

namespace RecipesApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Recipe> Recipe { get; set; }
    public DbSet<Nutrient> Nutrient { get; set; }
    public DbSet<UnitOfMeasurement> UnitOfMeasurement { get; set; }
    public DbSet<Tag> Tag { get; set; }
    public DbSet<RecipeTag> RecipeTag { get; set; }
    public DbSet<RecipeNutrient> RecipeNutrient { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}