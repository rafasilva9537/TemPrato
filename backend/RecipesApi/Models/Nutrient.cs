namespace RecipesApi.Models;

public class Nutrient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty; // TODO: redundant, another table?
}