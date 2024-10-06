using CeramicAlloyCalculator.Database.Tables;
using CeramicAlloyCalculator.Researcher.Calculation.Dto;
using Microsoft.VisualBasic;

namespace CeramicAlloyCalculator.Researcher.Calculation;

public class CalculationManager
{
    public CalculationResult Calculate(CalculationRequest request)
    {
        var t = request.InputCoefficients.tMin;
        var pg = request.InputCoefficients.pgMin;

        var result = new CalculationResult();
        while (t <= request.InputCoefficients.tMax)
        {
            var row = new Dictionary<int, double>();
            while (pg <= request.InputCoefficients.pgMax)
            {
                if (result.ts.Count == 0) {
                    result.pgs.Add(pg);
                }

                row.Add(pg, this.CalculateSolidity(request.Material, t, pg));
                pg += request.InputCoefficients.pgDelta;
            }

            result.sigmas.Add(t, row);
            result.ts.Add(t);
            t += request.InputCoefficients.tDelta;
            pg = request.InputCoefficients.pgMin;
        }

        return result;
    }

    public double CalculateSolidity(MaterialEntity material, double t, double pg)
    {
        return material.b0 + material.b1 * t + material.b2 * pg +
               material.b3 * t * pg + material.b4 * Math.Pow(t, 2) + material.b5 * Math.Pow(pg, 2) +
               material.b6 * Math.Pow(t, 2) * pg + material.b7 * t * Math.Pow(pg, 2) +
               material.b8 * Math.Pow(t, 2) * Math.Pow(pg, 2);
    }
}