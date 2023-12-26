namespace Roomex.GeoCoordinate.Api.Domain.DistanceCalculator;

public interface IDistanceCalculator
{
    protected const double EarthRadiusKm = 6371;

    /// <summary>
    /// Calculates the distance between two geo-coordinates in meters.
    /// </summary>
    /// <param name="firstCoordinate">The first geo-coordinate.</param>
    /// <param name="secondCoordinate">The second geo-coordinate.</param>
    /// <returns>The distance between the two geo-coordinates in kilometers.</returns>
    public double Calculate(Domain.Models.GeoCoordinate firstCoordinate, Domain.Models.GeoCoordinate secondCoordinate);
}