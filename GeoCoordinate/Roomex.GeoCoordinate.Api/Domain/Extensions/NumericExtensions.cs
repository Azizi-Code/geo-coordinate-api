namespace Roomex.GeoCoordinate.Api.Domain.Extensions;

public static class NumericExtensions
{
    public static double ToRadians(this double value) => (Math.PI / 180) * value;
    public static double ToKilometers(this double value) => value / 1000;
}