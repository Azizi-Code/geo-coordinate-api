namespace Roomex.GeoCoordinate.Api.Domain.Models;

public record GeoCoordinate
{
    public Latitude Latitude { get; init; }
    public Longitude Longitude { get; init; }

    public GeoCoordinate(Latitude latitude, Longitude longitude)
    {
        Latitude = latitude ?? throw new ArgumentNullException(nameof(latitude), "Latitude can not be null.");
        Longitude = longitude ?? throw new ArgumentNullException(nameof(longitude), "Longitude can not be null.");
    }
}