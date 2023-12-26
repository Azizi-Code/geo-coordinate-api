using System.Globalization;
using NSubstitute;
using Roomex.GeoCoordinate.Api.Domain.DistanceCalculator;
using Roomex.GeoCoordinate.Api.Features.DTOs;
using Roomex.GeoCoordinate.Api.Services;
using Xunit;
using GeoCoordinateModel = Roomex.GeoCoordinate.Api.Domain.Models.GeoCoordinate;

namespace Roomex.GeoCoordinate.Api.Tests.Services;

public class GeoCoordinatorServiceTests_GetDistance
{
    [Fact]
    public void ValidCoordinatesAndMetricCulture_ReturnsDistanceInKilometers()
    {
        var distanceCalculator = Substitute.For<IDistanceCalculator>();
        var localizationService = Substitute.For<IInternalLocalizationService>();
        distanceCalculator.Calculate(Arg.Any<GeoCoordinateModel>(), Arg.Any<GeoCoordinateModel>()).Returns(100);
        localizationService.GetLocalizationOptions(Arg.Any<string>()).Returns((true, new CultureInfo("en-GB")));
        var sut = new GeoCoordinatorService(distanceCalculator, localizationService);

        var result = sut.GetDistance(new CoordinateDTO(0, 0), new CoordinateDTO(1, 1), "en-GB");

        Assert.Equal("100.00", result.Distance);
        Assert.Equal("Kilometers (km)", result.Unit);
    }

    [Fact]
    public void ValidCoordinatesAndImperialCulture_ReturnsDistanceInMiles()
    {
        var distanceCalculator = Substitute.For<IDistanceCalculator>();
        var localizationService = Substitute.For<IInternalLocalizationService>();
        distanceCalculator.Calculate(Arg.Any<GeoCoordinateModel>(), Arg.Any<GeoCoordinateModel>()).Returns(100);
        localizationService.GetLocalizationOptions(Arg.Any<string>()).Returns((false, new CultureInfo("en-US")));
        var sut = new GeoCoordinatorService(distanceCalculator, localizationService);

        var result = sut.GetDistance(new CoordinateDTO(0, 0), new CoordinateDTO(1, 1), "en-US");

        Assert.Equal("62.14", result.Distance);
        Assert.Equal("Mile", result.Unit);
    }

    [Fact]
    public void NullCulture_ReturnsDistanceInKilometers()
    {
        var distanceCalculator = Substitute.For<IDistanceCalculator>();
        var localizationService = Substitute.For<IInternalLocalizationService>();
        distanceCalculator.Calculate(Arg.Any<GeoCoordinateModel>(), Arg.Any<GeoCoordinateModel>()).Returns(100);
        var sut = new GeoCoordinatorService(distanceCalculator, localizationService);

        var result = sut.GetDistance(new CoordinateDTO(0, 0), new CoordinateDTO(0, 0), null);

        Assert.Equal("100.00", result.Distance);
        Assert.Equal("Kilometers (km)", result.Unit);
    }
}