using CeramicAlloyCalculator.Database.Tables;
using CeramicAlloyCalculator.Researcher.InputValidation.Dto;

namespace CeramicAlloyCalculator.Researcher.Calculation.Dto;

public record CalculationRequest
{
    public InputCoefficients InputCoefficients;
    public MaterialEntity Material;
}