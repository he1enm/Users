namespace Users.Api.Domain.Users;

public record User
{
    public Guid Id;
    public string FirstName = string.Empty;
    public string LastName = string.Empty;
    public string Email = string.Empty;
}