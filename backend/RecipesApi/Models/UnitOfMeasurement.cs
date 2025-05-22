namespace RecipesApi.Models;

public class UnitOfMeasurement
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Nutrient> Nutrients { get; } = [];
}