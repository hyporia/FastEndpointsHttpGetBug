using FastEndpoints;
using FastEndpointsHttpGetBug;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddFastEndpoints(x => x.Assemblies = [typeof(GetWeather).Assembly]);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapOpenApi();
app.UseFastEndpoints(x => { x.Endpoints.AllowEmptyRequestDtos = true; });

app.Run();
