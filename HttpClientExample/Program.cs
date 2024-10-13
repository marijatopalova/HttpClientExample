using HttpClientExample.Services;
using Refit;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Named HttpClient for JSONPlaceholder API
builder.Services.AddHttpClient("JsonPlaceholderClient", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    httpClient.Timeout = TimeSpan.FromSeconds(30);
});

// Register Typed HttpClient for JSONPlaceholder API
builder.Services.AddHttpClient<TypedApiService>(httpClient =>
{
    httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    httpClient.Timeout = TimeSpan.FromSeconds(30);
});

// Register Refit Http Client for JSONPlaceholder API
builder.Services.AddRefitClient<IJsonPlaceholderApi>()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        client.Timeout = TimeSpan.FromSeconds(30);
    });


builder.Services.AddScoped<IPostsService, PostsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
