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
        var recipes = await _context.Recipe
            .Select(RecipeMappers.ProjectToStoryMainInfoDto)
            .ToListAsync();

        return Ok(recipes);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<RecipeDto>> GetRecipe([FromRoute] int id)
    {
        var recipe = await _context.Recipe.FirstOrDefaultAsync(r => r.Id == id);

        if (recipe is null) return StatusCode(StatusCodes.Status404NotFound);

        return Ok(recipe);
    }

    [HttpPost]
    public async Task<ActionResult<RecipeDto>> CreateRecipe(CreateRecipeDto createRecipeDto)
    {
        var newRecipe = createRecipeDto.ToRecipeModel();
        await _context.Recipe.AddAsync(newRecipe);
        await _context.SaveChangesAsync();
        var newRecipeDto = newRecipe.ToRecipeDto();

        return CreatedAtAction(nameof(GetRecipe), new { id = newRecipeDto.Id }, newRecipeDto);
    }
}
