using Microsoft.EntityFrameworkCore;
using RecipesApi.Data;
using RecipesApi.Dtos.Recipe;
using RecipesApi.Mappers;

namespace RecipesApi.Services;

public interface IRecipeService
{
    Task<RecipeDto> CreateRecipeAsync(CreateRecipeDto createRecipeDto);
    Task<RecipeDto?> UpdateRecipeAsync(UpdateRecipeDto updateRecipeDto);
    Task<bool> DeleteRecipeAsync(int recipeId);
    Task<RecipeDto?> GetRecipeAsync(int recipeId);
    Task<IList<RecipeMainInfoDto>> GetRecipesAsync();
}

public class RecipeService : IRecipeService
{
    private readonly ILogger<IRecipeService> _logger;
    private readonly AppDbContext _context;

    public RecipeService(ILogger<IRecipeService> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _context = dbContext;
    }

    public async Task<RecipeDto> CreateRecipeAsync(CreateRecipeDto createRecipeDto)
    {
        var newRecipe = createRecipeDto.ToRecipeModel();
        await _context.Recipe.AddAsync(newRecipe);
        await _context.SaveChangesAsync();
        
        return newRecipe.ToRecipeDto();
    }

    public async Task<bool> DeleteRecipeAsync(int recipeId)
    {
        var recipeToDelete = _context.Recipe.FirstOrDefault(r => r.Id == recipeId);

        if (recipeToDelete is null) return false;

        _context.Recipe.Remove(recipeToDelete);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<RecipeDto?> GetRecipeAsync(int recipeId)
    {
        var recipe = await _context.Recipe.FirstOrDefaultAsync(r => r.Id == recipeId);

        if (recipe is null) return null;
        return recipe.ToRecipeDto();
    }

    public async Task<IList<RecipeMainInfoDto>> GetRecipesAsync()
    {
        var recipesMainInfoDto = await _context.Recipe
            .Select(RecipeMappers.ProjectToStoryMainInfoDto)
            .ToListAsync();

        return recipesMainInfoDto;
    }

    public async Task<RecipeDto?> UpdateRecipeAsync(UpdateRecipeDto updateRecipeDto)
    {
        var recipeToUpdate = _context.Recipe.FirstOrDefault(r => r.Id == updateRecipeDto.Id);

        if (recipeToUpdate is null) return null;

        _context.Entry(recipeToUpdate).CurrentValues.SetValues(updateRecipeDto);
        recipeToUpdate.UpdatedAt = DateTimeOffset.Now;
        await _context.SaveChangesAsync();

        return recipeToUpdate.ToRecipeDto();
    }
}