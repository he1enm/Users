using System.Net.Http.Json;
using Users.Api.Models;

namespace Users.Api.Services;

public class ChucknorrisService
{
    private readonly HttpClient _httpClient;

    public ChucknorrisService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ChuckNorrisJoke> GetRandomJokeAsync()
    {
        var joke = await _httpClient.GetFromJsonAsync<ChuckNorrisJoke>("jokes/random");
        return joke!;
    }
    public async Task<IEnumerable<string>> GetCategoriesAsync()
    {
        var categories = await _httpClient.GetFromJsonAsync<IEnumerable<string>>("jokes/categories");
        return categories ?? Enumerable.Empty<string>();
    }
    public async Task<ChuckNorrisJoke> GetRandomJokeByCategoryAsync(string category)
    {
        var joke = await _httpClient.GetFromJsonAsync<ChuckNorrisJoke>($"jokes/random?category={category}");
        return joke!;
    }

}
