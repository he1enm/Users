namespace Users.Api.Infrastructure.Services.Jokes.Options;

public sealed class ChuckNorisOptions
{
    public const string SectionName = "ChuckNorris";

    public Uri Host { get; init; } = null!;
}