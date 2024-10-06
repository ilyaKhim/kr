namespace CeramicAlloyCalculator.Researcher.Calculation.Dto;

public record CalculationResult
{
    public List<int> ts = new();
    public List<int> pgs = new();
    public Dictionary<int, Dictionary<int, double>> sigmas = new();
}