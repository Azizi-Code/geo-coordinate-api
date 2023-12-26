using Roomex.GeoCoordinate.Api.Domain.Models;
using Roomex.GeoCoordinate.Api.Features.Factories;
using Xunit;
using GeoCoordinateModel = Roomex.GeoCoordinate.Api.Domain.Models.GeoCoordinate;

namespace Roomex.GeoCoordinate.Api.Tests.Domain.DistanceCalculator;

public class DistanceCalculatorFormula1Tests_Calculate
{
    [Fact]
    public void ValidCoordinates_ReturnsDistance()
    {
        var firstCoordinate = new GeoCoordinateModel(new Latitude(40), new Longitude(-75));
        var secondCoordinate = new GeoCoordinateModel(new Latitude(34), new Longitude(-118));
        var distanceCalculator = DistanceCalculatorFactory.GetInstance(CalculatorType.Formula1);

        double result = distanceCalculator.Calculate(firstCoordinate, secondCoordinate);

        Assert.InRange(result, 3800, 4000);
    }

    [Fact]
    public void SameCoordinates_ReturnsZero()
    {
        var coordinate = new GeoCoordinateModel(new Latitude(40), new Longitude(-75));
        var distanceCalculator = DistanceCalculatorFactory.GetInstance(CalculatorType.Formula1);

        double result = distanceCalculator.Calculate(coordinate, coordinate);

        Assert.InRange(result,0, 20);
    }
}