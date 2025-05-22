using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesApi.Models;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Recipe> Recipes { get; } = [];
    public ICollection<RecipeTag> RecipeTags { get; } = [];
}
