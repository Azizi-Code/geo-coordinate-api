using System.Globalization;

namespace Roomex.GeoCoordinate.Api.Services;

public interface IInternalLocalizationService
{
    public (bool IsMetric, CultureInfo CultureInfo) GetLocalizationOptions(string culture);
}

public class InternalLocalizationService : IInternalLocalizationService
{
    public (bool IsMetric, CultureInfo CultureInfo) GetLocalizationOptions(string culture)
    {
        {
            try
            {
                var cultureInfo = new CultureInfo(culture);
                var regionInfo = new RegionInfo(cultureInfo.LCID);
                return (regionInfo.IsMetric, cultureInfo);
            }
            catch
            {
                //here we can use custom exception instead.
                throw new ArgumentException($"Culture name '{culture}' is not supported.");
            }
        }
    }
}