using Microsoft.AspNetCore.Mvc;
using Users.Api.Common.Interfaces.Services;
using Users.Api.Models; 

namespace Users.Api.Controllers;

[Route("joke")]
public class JokesController(IJokesService service) : ControllerBase
{
    [HttpGet("random")]
    public async Task<IActionResult> GetJoke()
    {
        var joke = await service.GetRandomJokeAsync();
        return Ok(JokeResponse.FromDomainModel(joke));
    }
    [HttpGet("categories")]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await service.GetCategoriesAsync();
        return Ok(categories);
    }
    [HttpGet("random/{category}")]
    public async Task<IActionResult> GetJokeByCategory(string category)
    {
        var joke = await service.GetRandomJokeByCategoryAsync(category);
        return Ok(JokeResponse.FromDomainModel(joke));
    }

}
