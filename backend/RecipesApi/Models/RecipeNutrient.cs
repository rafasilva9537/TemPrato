namespace RecipesApi.Models;

public class RecipeNutrient
{
    public int RecipeId { get; set; }
    public int NutrientId { get; set; }

    public Recipe Recipe { get; set; } = null!;
    public Nutrient Nutrient { get; set; } = null!;
}
