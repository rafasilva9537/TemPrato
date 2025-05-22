using System.Linq.Expressions;
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
        };
    }

    public static UpdateRecipeDto ToUpdateRecipeDto(this Recipe recipeModel)
    {
        return new UpdateRecipeDto
        {
            Id = recipeModel.Id,
            Name = recipeModel.Name,
            Description = recipeModel.Description,
            Text = recipeModel.Text,
        };
    }

    public static RecipeDto ToRecipeDto(this Recipe recipeModel)
    {
        return new RecipeDto
        {
            Id = recipeModel.Id,
            Name = recipeModel.Name,
            Description = recipeModel.Description,
            Text = recipeModel.Text,
            CreatedAt = recipeModel.CreatedAt,
            UpdatedAt = recipeModel.UpdatedAt,
        };
    }

    public static RecipeMainInfoDto ToRecipeMainInfoDto(this Recipe recipeModel)
    {
        return new RecipeMainInfoDto
        {
            Id = recipeModel.Id,
            Name = recipeModel.Name,
            Description = recipeModel.Description,
            CreatedAt = recipeModel.CreatedAt,
            UpdatedAt = recipeModel.UpdatedAt,
        };
    }

    // Why use Project if extension method ToRecipeMainInfoDto already does the mapping?
    // Because LINQ doesn't know how to read extension methods with closed statements. It will make an query taking all the columns of a table in a select, even tough the extension method doesn't have that column. Tables with to many columns will waste resources.
    public static Expression<Func<Recipe, RecipeMainInfoDto>> ProjectToStoryMainInfoDto = (recipeModel) =>
    new RecipeMainInfoDto
    {
        Id = recipeModel.Id,
        Name = recipeModel.Name,
        Description = recipeModel.Description,
        CreatedAt = recipeModel.CreatedAt,
        UpdatedAt = recipeModel.UpdatedAt,
    };


    // Dto to Model
    public static Recipe ToRecipeModel(this CreateRecipeDto createRecipeDto)
    {
        return new Recipe
        {
            Name = createRecipeDto.Name,
            Description = createRecipeDto.Description,
            Text = createRecipeDto.Text,
        };
    }

    public static Recipe ToRecipeModel(this UpdateRecipeDto updateRecipeDto)
    {
        return new Recipe
        {
            Id = updateRecipeDto.Id,
            Name = updateRecipeDto.Name,
            Description = updateRecipeDto.Description,
            Text = updateRecipeDto.Text,
        };
    }
}