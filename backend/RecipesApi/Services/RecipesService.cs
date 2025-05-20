using RecipesApi.Dtos.Recipe;

namespace RecipesApi.Services;

public interface IRecipeService
{
    Task<RecipeDto> CreateRecipeAsync(CreateRecipeDto createRecipeDto);
    Task<RecipeDto> UpdateRecipeAsync(UpdateRecipeDto createRecipeDto);
    Task<bool> DeleteRecipeAsync(int recipeId);
    Task<RecipeDto> GetRecipeAsync(int recipeId);
    Task<IList<RecipeMainInfoDto>> GetRecipesAsync();
}

public class RecipeService : IRecipeService
{
    public Task<RecipeDto> CreateRecipeAsync(CreateRecipeDto createRecipeDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteRecipeAsync(int recipeId)
    {
        throw new NotImplementedException();
    }

    public Task<RecipeDto> GetRecipeAsync(int recipeId)
    {
        throw new NotImplementedException();
    }

    public Task<IList<RecipeMainInfoDto>> GetRecipesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<RecipeDto> UpdateRecipeAsync(UpdateRecipeDto createRecipeDto)
    {
        throw new NotImplementedException();
    }
}