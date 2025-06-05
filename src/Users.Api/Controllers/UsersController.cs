using Microsoft.AspNetCore.Mvc;
using Users.Api.Models;
using Users.Api.Services;
using Users.Api.Domain.Users;

namespace Users.Api.Controllers;
[ApiController]
[Route("users")]
public class UserController(UserService userService) : ControllerBase
{
    private readonly UserService _userService = userService;

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
        => Ok(await _userService.GetAllUsersAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return user is not null ? Ok(user) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] User user)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var newUser = await _userService.RegisterUserAsync(user);
        return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] User user)
    {
        var updated = await _userService.UpdateUserAsync(id, user);
        return updated is not null ? Ok(updated) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var deleted = await _userService.DeleteUserAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
