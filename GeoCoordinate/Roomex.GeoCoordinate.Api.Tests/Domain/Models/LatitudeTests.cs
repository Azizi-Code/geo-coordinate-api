using Roomex.GeoCoordinate.Api.Domain.Models;
using Xunit;

namespace Roomex.GeoCoordinate.Api.Tests.Domain.Models;

public class LatitudeTests_Ctor
{
    [Fact]
    public void ValidValue_ReturnsLatitude()
    {
        double validValue = 45;

        var latitude = new Latitude(validValue);

        Assert.Equal(validValue, latitude.Value);
    }

    [Theory]
    [InlineData(-91)]
    [InlineData(91)]
    public void InvalidValue_ThrowsException(double invalidValue)
    {
        var result = Record.Exception(() => new Latitude(invalidValue));

        Assert.IsType<ArgumentException>(result);
        Assert.Equal("Latitude must be between 90 and -90", result.Message);
    }

    [Theory]
    [InlineData(-90)]
    [InlineData(90)]
    public void MaxValidValue_ReturnsLatitude(double validValue)
    {
        var result = new Latitude(validValue);

        Assert.Equal(validValue, result.Value);
    }
}