using Microsoft.AspNetCore.Mvc;
using RecipesApi.Services;

namespace RecipesApi.Controllers;

[ApiController]
[Route("api/")]
public class RecipesController : ControllerBase
{
    private readonly IRecipeService _recipeService;
    private readonly ILogger<RecipesController> _logger;

    public RecipesController(ILogger<RecipesController> logger, IRecipeService recipeService)
    {
        _logger = logger;
        _recipeService = recipeService;
    }

    [HttpGet]
    public IActionResult GetRecipes()
    {
        return Ok("Get recipes page - test");
    }
}
