using Roomex.GeoCoordinate.Api.Domain.Extensions;

namespace Roomex.GeoCoordinate.Api.Domain.DistanceCalculator;

public class DistanceCalculatorFormula2 : IDistanceCalculator
{
    public double Calculate(Domain.Models.GeoCoordinate firstCoordinate, Domain.Models.GeoCoordinate secondCoordinate)
    {
        double latitude1 = firstCoordinate.Latitude.Value.ToRadians();
        double longitude1 = firstCoordinate.Longitude.Value.ToRadians();
        double latitude2 = secondCoordinate.Latitude.Value.ToRadians();
        double longitude2 = secondCoordinate.Longitude.Value.ToRadians();

        double deltaLatitude = latitude2 - latitude1;
        double deltaLongitude = longitude2 - longitude1;

        double resultA = Math.Sin(deltaLatitude / 2) * Math.Sin(deltaLatitude / 2) +
                         Math.Cos(latitude1) * Math.Cos(latitude2) *
                         Math.Sin(deltaLongitude / 2) * Math.Sin(deltaLongitude / 2);
        double resultB = 2 * Math.Atan2(Math.Sqrt(resultA), Math.Sqrt(1 - resultA));

        double distance = IDistanceCalculator.EarthRadiusKm * resultB;
        return distance;
    }
}