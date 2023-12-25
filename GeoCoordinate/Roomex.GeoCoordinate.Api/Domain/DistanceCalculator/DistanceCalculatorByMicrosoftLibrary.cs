using Roomex.GeoCoordinate.Api.Domain.Extensions;

namespace Roomex.GeoCoordinate.Api.Domain.DistanceCalculator;

public class DistanceCalculatorByMicrosoftLibrary : IDistanceCalculator
{
    public double Calculate(Models.GeoCoordinate firstCoordinate, Models.GeoCoordinate secondCoordinate)
    {
        var coordinateA =
            new GeoCoordinatePortable.GeoCoordinate(firstCoordinate.Latitude.Value, firstCoordinate.Longitude.Value);
        var coordinateB =
            new GeoCoordinatePortable.GeoCoordinate(secondCoordinate.Latitude.Value, secondCoordinate.Longitude.Value);

        var distance = coordinateA.GetDistanceTo(coordinateB).ToKilometers();
        return distance;
    }
}