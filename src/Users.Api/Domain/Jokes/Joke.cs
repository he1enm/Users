
namespace Users.Api.Domain.Jokes;

public sealed class Joke
{

    public string Id { get; set; }
    public string JokeText { get; set; }

    public Joke(string id, string jokeText)
    {
        Id = id;
        JokeText = jokeText;
    }

     public static Joke Load(
        string id,
        string text) => new(id, text);
}
