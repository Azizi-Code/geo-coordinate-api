using Roomex.GeoCoordinate.Api.Domain.DistanceCalculator;

namespace Roomex.GeoCoordinate.Api.Features.Factories;

public class DistanceCalculatorFactory
{
    public static IDistanceCalculator GetInstance(CalculatorType type) =>
        type switch
        {
            CalculatorType.Formula1 => new DistanceCalculatorFormula1(),
            CalculatorType.Formula2 => new DistanceCalculatorFormula2(),
            CalculatorType.MicrosoftLibrary => new DistanceCalculatorByMicrosoftLibrary(),
            _ => new DistanceCalculatorFormula1()
        };
}