namespace RecipesApi.Dtos.Recipe;

public class UpdateRecipeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
}