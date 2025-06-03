using Microsoft.AspNetCore.Mvc;
using Users.Api.Models;
using Users.Api.Services;

namespace Users.Api.Controllers;

[ApiController]
[Route("users")]
public class UserController(UserService userService) : ControllerBase
{
    private readonly UserService _userService = userService;

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(Guid id)
    {
        var user = _userService.GetUserById(id);
        return user is not null ? Ok(user) : NotFound();
    }

    [HttpPost]
    public IActionResult RegisterUser([FromBody] RegisterUserRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var newUser = _userService.RegisterUser(request);

        return CreatedAtAction(
            nameof(GetUserById),
            new { id = newUser.Id },
            newUser
        );
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, [FromBody] UpdateUserRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedUser = _userService.UpdateUser(id, request);

        return updatedUser is not null ? Ok(updatedUser) : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
        var deleted = _userService.DeleteUser(id);
        return deleted ? NoContent() : NotFound();
    }
}
