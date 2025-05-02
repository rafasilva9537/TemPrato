using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RecipesApi.Models;

namespace RecipesApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Nutrient> Nutrients { get; set; }
    public DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}