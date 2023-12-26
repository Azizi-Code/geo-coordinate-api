using Roomex.GeoCoordinate.Api.Domain.Extensions;

namespace Roomex.GeoCoordinate.Api.Domain.DistanceCalculator;

public class DistanceCalculatorFormula1 : IDistanceCalculator
{
    public double Calculate(Domain.Models.GeoCoordinate firstCoordinate, Domain.Models.GeoCoordinate secondCoordinate)
    {
        double latitude1 = firstCoordinate.Latitude.Value.ToRadians();
        double latitude2 = secondCoordinate.Latitude.Value.ToRadians();
        double delta = (firstCoordinate.Longitude.Value - secondCoordinate.Longitude.Value).ToRadians();

        double cosP = Math.Sin(latitude1) * Math.Sin(latitude2) +
                      Math.Cos(latitude1) * Math.Cos(latitude2) * Math.Cos(delta);

        var distance = IDistanceCalculator.EarthRadiusKm * Math.Acos(cosP);
        return distance;
    }
}