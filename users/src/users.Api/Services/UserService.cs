using Users.Api.Domain.Users;
using Users.Api.Models;

namespace Users.Api.Services;

public class UserService
{
    private static readonly List<User> _users = new();

    public IEnumerable<UserResponse> GetAllUsers()
    {
        return _users.Select(ToUserResponse);
    }

    public UserResponse? GetUserById(Guid id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        return user is not null ? ToUserResponse(user) : null;
    }

    public UserResponse RegisterUser(RegisterUserRequest request)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };

        _users.Add(user);
        return ToUserResponse(user);
    }

    private static UserResponse ToUserResponse(User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            FullName = $"{user.FirstName} {user.LastName}",
            Email = user.Email
        };
    }

    public UserResponse? UpdateUser(Guid id, UpdateUserRequest request)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user is null)
            return null;

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;

        return ToUserResponse(user);
    }

    public bool DeleteUser(Guid id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user is null)
            return false;

        _users.Remove(user);
        return true;
    }

}


