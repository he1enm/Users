
using Users.Api.Common.Interfaces.Services;

namespace Users.Api.Infrastructure.Services.Jokes;

public class CustomJokeService : IJokesService
{
    public Task<Domain.Jokes.Joke> GetRandomJokeAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string[]> GetCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Jokes.Joke> GetRandomJokeByCategoryAsync(string category)
    {
        throw new NotImplementedException();
    }
}