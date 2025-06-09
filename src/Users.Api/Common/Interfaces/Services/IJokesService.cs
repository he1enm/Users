using Users.Api.Domain.Jokes;


namespace Users.Api.Common.Interfaces.Services
{
    public interface IJokesService
    {
        Task<Joke> GetRandomJokeAsync();

        Task<string[]> GetCategoriesAsync(); 

        Task<Joke> GetRandomJokeByCategoryAsync(string category);   
    }
}