using Microsoft.AspNetCore.Mvc;
using Users.Api.Services;

namespace Users.Api.Controllers;

[ApiController]
[Route("joke")]
public class ChucknorrisController(ChucknorrisService chucknorrisService) : ControllerBase
{
    [HttpGet("random")]
    public async Task<IActionResult> GetJoke()
    {
        var joke = await chucknorrisService.GetRandomJokeAsync();
        return Ok(joke);
    }
    [HttpGet("categories")]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await chucknorrisService.GetCategoriesAsync();
        return Ok(categories);
    }
    [HttpGet("random/{category}")]
    public async Task<IActionResult> GetJokeByCategory(string category)
    {
        var joke = await chucknorrisService.GetRandomJokeByCategoryAsync(category);
        return Ok(joke);
    }

}
