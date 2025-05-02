namespace RecipesApi.Models;

public class Nutrient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;

    public UnitOfMeasurement UnitOfMeasurement { get; set; } = null!;
    public Recipe Recipe { get; set; } = null!;
}