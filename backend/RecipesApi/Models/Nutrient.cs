namespace RecipesApi.Models;

public class Nutrient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int UnitId { get; set; }

    public UnitOfMeasurement Unit { get; set; } = null!;
    public ICollection<Recipe> Recipes { get; set; } = [];
    public ICollection<RecipeNutrient> RecipeNutrients { get; } = [];
}