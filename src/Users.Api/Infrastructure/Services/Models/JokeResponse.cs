using System.Text.Json.Serialization;

namespace Users.Api.Infrastructure.Services.Joke.Models;

public class JokeResponse
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = null!;

    [JsonPropertyName("value")]
    public string Text { get; init; } = null!;

    public Domain.Jokes.Joke ToDomainModel() => Domain.Jokes.Joke.Load(Id, Text);
}