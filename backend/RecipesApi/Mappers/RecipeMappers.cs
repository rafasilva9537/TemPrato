using RecipesApi.Dtos.Recipe;
using RecipesApi.Models;

namespace RecipesApi.Mappers;

public static class RecipeMappers
{
    // Model to Dto
    public static CreateRecipeDto ToCreateRecipeDto(this Recipe recipeModel)
    {
        return new CreateRecipeDto
        {
            Name = recipeModel.Name,
            Description = recipeModel.Description,
            CreatedAt = recipeModel.CreatedAt,
            UpdatedAt = recipeModel.UpdatedAt,
        };
    }

    public static UpdateRecipeDto ToUpdateRecipeDto(this Recipe recipeModel)
    {
        return new UpdateRecipeDto
        {
            Name = recipeModel.Name,
            Description = recipeModel.Description,
            UpdatedAt = recipeModel.UpdatedAt,
        };
    }

    public static RecipeMainInfoDto ToRecipeMainInfoDto(this Recipe recipeModel)
    {
        return new RecipeMainInfoDto
        {
            Name = recipeModel.Name,
            Description = recipeModel.Description,
            CreatedAt = recipeModel.CreatedAt,
            UpdatedAt = recipeModel.UpdatedAt,
        };
    }


    // Dto to Model
}