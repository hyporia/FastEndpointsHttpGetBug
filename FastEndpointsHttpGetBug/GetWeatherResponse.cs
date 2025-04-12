namespace FastEndpointsHttpGetBug;

public class GetWeatherResponse(string City, DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string City { get; } = City;

    public DateOnly Date { get; } = Date;
    public int TemperatureC { get; } = TemperatureC;

    public string? Summary { get; } = Summary;
}