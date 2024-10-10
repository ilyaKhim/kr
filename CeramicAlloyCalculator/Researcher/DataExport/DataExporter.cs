using System.Runtime.InteropServices.JavaScript;
using CeramicAlloyCalculator.Researcher.Calculation.Dto;
using Spire.Pdf.Exporting.XPS.Schema;
using Spire.Xls;

namespace CeramicAlloyCalculator.Researcher.DataExport;

public class DataExporter
{
    public void SaveToExcelFile(string fileName, CalculationRequest calculationRequest, CalculationResult calculationResult)
    {
        Workbook wb = new Workbook();
        wb.Worksheets.Clear();
        Worksheet ws = wb.Worksheets.Add("Расчеты");

        string[,] rows = new string[calculationResult.ts.Count + 1,calculationResult.pgs.Count + 1];

        var i = 1;
        foreach (var pg in calculationResult.pgs)
        {
            rows[0, i] = pg.ToString();
            i++;
        }

        i = 1;
        foreach (var t in calculationResult.ts)
        {
            rows[i, 0] = t.ToString();
            i++;
        }

        i = 1;
        var j = 1;
        foreach(var row in calculationResult.sigmas)
        {
            foreach (var column in row.Value)
            {
                rows[i, j] = column.Value.ToString();
                j++;
            }

            i++;
            j = 1;
        }

        ws.InsertArray(rows, 1, 1);
        ws.AllocatedRange.AutoFitColumns();
        wb.SaveToFile(@fileName, ExcelVersion.Version2016);
    }
}