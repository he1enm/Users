using Users.Api.Services;
using Microsoft.EntityFrameworkCore;
using Users.Api.Data;
using Users.Api.Infrastructure.Services.Jokes;
using Users.Api.Common.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddScoped<UserService>();
builder.Services.AddDbContext<UsersDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddHttpClient<IJokesService, ChuckJokeService>(client =>
{
    client.BaseAddress = new Uri("https://api.chucknorris.io/");
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
