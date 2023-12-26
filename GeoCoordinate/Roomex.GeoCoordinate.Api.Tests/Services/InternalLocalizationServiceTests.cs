using System.Globalization;
using Roomex.GeoCoordinate.Api.Services;
using Xunit;

namespace Roomex.GeoCoordinate.Api.Tests.Services;

public class InternalLocalizationServiceTests_GetLocalizationOptions
{
    [Theory]
    [InlineData("en-US", false)]
    [InlineData("en-GB", true)]
    [InlineData("fr-FR", true)]
    public void ValidCulture_ReturnsExpectedValues(string culture, bool isMetric)
    {
        var sut = new InternalLocalizationService();

        var result = sut.GetLocalizationOptions(culture);

        Assert.True(result.IsMetric == isMetric);
        Assert.Equal(new CultureInfo(culture), result.CultureInfo);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("invalid-culture")]
    public void InvalidCulture_ThrowsException(string culture)
    {
        var sut = new InternalLocalizationService();

        var result = Record.Exception(() => sut.GetLocalizationOptions(culture));

        Assert.IsType<ArgumentException>(result);
    }
}