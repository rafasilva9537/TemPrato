using System.ComponentModel.DataAnnotations;

namespace RecipesApi.Dtos.Recipe;

public class CreateRecipeDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [Required]
    public string Text { get; set; } = string.Empty;
}