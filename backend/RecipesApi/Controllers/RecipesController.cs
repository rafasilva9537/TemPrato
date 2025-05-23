using Microsoft.AspNetCore.Mvc;
using RecipesApi.Data;
using RecipesApi.Dtos.Recipe;
using RecipesApi.Services;
using RecipesApi.Mappers;
using Microsoft.EntityFrameworkCore;

namespace RecipesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly IRecipeService _recipeService;
    private readonly ILogger<RecipesController> _logger;
    private readonly AppDbContext _context;

    public RecipesController(ILogger<RecipesController> logger, IRecipeService recipeService, AppDbContext dbContext)
    {
        _logger = logger;
        _recipeService = recipeService;
        _context = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<RecipeMainInfoDto>> GetRecipes()
    {
        var recipes = await _recipeService.GetRecipesAsync();

        return Ok(recipes);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<RecipeDto>> GetRecipe([FromRoute] int recipeId)
    {
        var recipe = await _recipeService.GetRecipeAsync(recipeId);

        if (recipe is null) return NotFound();

        return Ok(recipe);
    }

    [HttpPost]
    public async Task<ActionResult<RecipeDto>> CreateRecipe(CreateRecipeDto createRecipeDto)
    {
        var newRecipeDto = await _recipeService.CreateRecipeAsync(createRecipeDto);

        return CreatedAtAction(nameof(GetRecipe), new { id = newRecipeDto.Id }, newRecipeDto);
    }
}
