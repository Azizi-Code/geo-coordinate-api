using Roomex.GeoCoordinate.Api.Domain.Models;
using Xunit;
using GeoCoordinateModel = Roomex.GeoCoordinate.Api.Domain.Models.GeoCoordinate;

namespace Roomex.GeoCoordinate.Api.Tests.Domain.Models;

public class GeoCoordinateTests_Ctor
{
    [Fact]
    public void ValidValues_ReturnsGeoCoordinate()
    {
        var validLatitude = new Latitude(30);
        var validLongitude = new Longitude(-45);

        var geoCoordinate = new GeoCoordinateModel(validLatitude, validLongitude);

        Assert.Equal(validLatitude, geoCoordinate.Latitude);
        Assert.Equal(validLongitude, geoCoordinate.Longitude);
    }

    [Fact]
    public void NullLatitude_ThrowsException()
    {
        Latitude nullLatitude = null!;
        var validLongitude = new Longitude(10);

        var result = Record.Exception(() => new GeoCoordinateModel(nullLatitude, validLongitude));

        Assert.IsType<ArgumentNullException>(result);
        Assert.Equal("Latitude can not be null. (Parameter 'latitude')", result.Message);
    }

    [Fact]
    public void NullLongitude_ThrowsException()
    {
        var validLatitude = new Latitude(10);
        Longitude nullLongitude = null!;

        var result = Record.Exception(() => new GeoCoordinateModel(validLatitude, nullLongitude));

        Assert.IsType<ArgumentNullException>(result);
        Assert.Equal("Longitude can not be null. (Parameter 'longitude')", result.Message);
    }
}