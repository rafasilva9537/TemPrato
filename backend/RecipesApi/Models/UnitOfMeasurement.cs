namespace RecipesApi.Models;

public class UnitOfMeasurement
{
    public string Name { get; set; } = string.Empty;

    public ICollection<Nutrient> Nutrients { get; } = [];
}