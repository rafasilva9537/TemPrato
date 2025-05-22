namespace RecipesApi.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public ICollection<Nutrient> Nutrients { get; } = [];
    public ICollection<RecipeNutrient> RecipeNutrients { get; } = [];
    public ICollection<Tag> Tags { get; } = [];
    public ICollection<RecipeTag> RecipeTags { get; } = [];
}