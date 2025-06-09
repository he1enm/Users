
using Users.Api.Common.Interfaces.Services;
using Users.Api.Infrastructure.Services.Joke.Models;
namespace Users.Api.Infrastructure.Services.Jokes

{
    public class ChuckJokeService(HttpClient httpClient) : IJokesService
    {
        public async Task<Domain.Jokes.Joke> GetRandomJokeAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "jokes/random");
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadFromJsonAsync<JokeResponse>();
        var joke = responseContent?.ToDomainModel();

        return joke ?? throw new Exception("Failed to fetch a joke.");
        }

        public async Task<string[]> GetCategoriesAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "jokes/categories");
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var categories = await response.Content.ReadFromJsonAsync<string[]>();
            return categories ?? throw new Exception("Failed to fetch categories.");
        }

        public async Task<Domain.Jokes.Joke> GetRandomJokeByCategoryAsync(string category)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"jokes/random?category={Uri.EscapeDataString(category)}");
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var jokeData = await response.Content.ReadFromJsonAsync<JokeResponse>();
            return jokeData?.ToDomainModel() ?? throw new Exception("Failed to fetch a joke.");
        }
    }
}