using Users.Api.Services;
using Microsoft.EntityFrameworkCore;
using Users.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UsersDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<UserService>();

builder.Services.AddHttpClient<ChucknorrisService>(client =>
{
    client.BaseAddress = new Uri("https://api.chucknorris.io/");
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
