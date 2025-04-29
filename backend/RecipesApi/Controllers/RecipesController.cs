using Microsoft.AspNetCore.Mvc;

namespace RecipesApi.Controllers;

[ApiController]
[Route("api/")]
public class RecipesController : ControllerBase
{
    private readonly ILogger<RecipesController> _logger;

    public RecipesController(ILogger<RecipesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetRecipes()
    {
        return Ok("Get recipes page - test");
    }
}
