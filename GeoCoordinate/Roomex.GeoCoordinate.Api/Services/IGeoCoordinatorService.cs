using System.Globalization;
using Roomex.GeoCoordinate.Api.Domain.DistanceCalculator;
using Roomex.GeoCoordinate.Api.Features.DTOs;
using Roomex.GeoCoordinate.Api.Features.Mappers;
using Roomex.GeoCoordinate.Api.Features.Responses;

namespace Roomex.GeoCoordinate.Api.Services;

public interface IGeoCoordinatorService
{
    DistanceResponse GetDistance(CoordinateDTO coordinateA, CoordinateDTO coordinateB, string? culture);
}

public class GeoCoordinatorService(
    IDistanceCalculator distanceCalculator,
    IInternalLocalizationService internalLocalizationService) : IGeoCoordinatorService
{
    public DistanceResponse GetDistance(CoordinateDTO coordinateA, CoordinateDTO coordinateB, string? culture)
    {
        //Here as you can see in below comment we can used factory method for creating particular instance according to conditions. 
        //var calculator = DistanceCalculatorFactory.GetInstance(CalculatorType.Formula1);
        var distance = distanceCalculator.Calculate(coordinateA.ToModel(), coordinateB.ToModel());
        if (string.IsNullOrEmpty(culture))
            return ToDistanceResponse(distance.ToString("F2", CultureInfo.InvariantCulture));

        var options = internalLocalizationService.GetLocalizationOptions(culture);
        if (!options.IsMetric)
            distance = KilometersToMiles(distance);

        return ToDistanceResponse(distance.ToString("F2", options.CultureInfo), options.IsMetric);
    }

    private DistanceResponse ToDistanceResponse(string distance, bool isMetric = true) =>
        isMetric
            ? new DistanceResponse(distance, "Kilometers (km)")
            : new DistanceResponse(distance, "Mile");


    private double KilometersToMiles(double kilometers)
    {
        const double milesPerKilometer = 0.621371;
        return kilometers * milesPerKilometer;
    }
}