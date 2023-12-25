namespace Roomex.GeoCoordinate.Api.Domain.Models;

public record Latitude
{
    public double Value { get; init; }

    public Latitude(double value)
    {
        if (value > 90 || value < -90)
            throw new ArgumentException("Longitude must be between 180 and -180");
        Value = value;
    }
}