namespace Roomex.GeoCoordinate.Api.Domain.Models;

public record Longitude
{
    public double Value { get; init; }

    public Longitude(double value)
    {
        if (value > 180 || value < -180)
            throw new ArgumentException("Longitude must be between 90 and -90");
        Value = value;
    }
}