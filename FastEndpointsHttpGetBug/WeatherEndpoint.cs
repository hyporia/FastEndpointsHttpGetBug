using FastEndpoints;
using System.ComponentModel;

namespace FastEndpointsHttpGetBug;

[Description("Get weather.")]
public class WeatherEndpoint : Endpoint<GetWeather, GetWeatherResponse>
{
    public override void Configure()
    {
        Get("/api/weather");
        AllowAnonymous();
        Description(b => b
            .Produces<GetWeatherResponse>(200, "application/json")
            .WithTags("Weather"));
    }
    public static string[] summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public override async Task HandleAsync(GetWeather query, CancellationToken ct)
    {
        var response = new GetWeatherResponse(query.City, DateOnly.FromDateTime(DateTime.Now), 25, summaries[Random.Shared.Next(summaries.Length)]);
        await SendAsync(response, cancellation: ct);
    }
}