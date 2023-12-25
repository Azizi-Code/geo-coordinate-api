using Roomex.GeoCoordinate.Api.Domain.Models;
using Xunit;

namespace Roomex.GeoCoordinate.Api.Tests.Domain.Models;

public class LongitudeTests_Ctor
{
    [Fact]
    public void ValidValue_ReturnsLongitude()
    {
        double validValue = 45;

        var latitude = new Longitude(validValue);

        Assert.Equal(validValue, latitude.Value);
    }

    [Theory]
    [InlineData(-181)]
    [InlineData(181)]
    public void InvalidValue_ThrowsException(double invalidValue)
    {
        var result = Record.Exception(() => new Longitude(invalidValue));

        Assert.IsType<ArgumentException>(result);
        Assert.Equal("Longitude must be between 180 and -180", result.Message);
    }

    [Theory]
    [InlineData(-180)]
    [InlineData(180)]
    public void MaxValidValue_ReturnsLatitude(double validValue)
    {
        var result = new Longitude(validValue);

        Assert.Equal(validValue, result.Value);
    }
}