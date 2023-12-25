namespace Roomex.GeoCoordinate.Api.Domain.Models;

public record Latitude
{
    public double Value { get; init; }

    public Latitude(double value)
    {
        if (value > 90 || value < -90)
            throw new ArgumentException("Latitude must be between 90 and -90");
        Value = value;
    }
}