using System.Windows.Forms.DataVisualization.Charting;
using CeramicAlloyCalculator.Researcher.Calculation.Dto;

namespace CeramicAlloyCalculator;

public partial class ChartForm : Form
{
    private readonly CalculationRequest _calculationRequest;
    private readonly CalculationResult _calculationResult;
    private readonly Chart _chart;

    public ChartForm(CalculationRequest calculationRequest, CalculationResult calculationResult)
    {
        _calculationRequest = calculationRequest;
        _calculationResult = calculationResult;
        
        InitializeComponent();

        Size = new Size(1400, 900);
        Resize += OnFormResize;
        Text = "Визуализация расчета";
        
        _chart = new Chart();
        _chart.Size = new Size(Size.Width, Size.Height - 40);
        _chart.Location = new Point(0, 0);
        _chart.Legends.Add(new Legend());
        _chart.ChartAreas.Add(new ChartArea()
        {
            Name = "Chart 1",
            AxisX = new Axis()
            {
                Title = "Pg (атм)",
            },
            AxisY = new Axis()
            {
                Title = "σ (%)"
            }
        });
        Controls.Add(_chart);
        
        DrawChart(calculationResult);
    }
    
    private void DrawChart(CalculationResult calculationResult)
    {
        _chart.Series.Clear();
        
        int i = 0;
        int j = 1;
        var rnd = new Random();
        foreach (var outerEntry in calculationResult.sigmas)
        {
            var series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));;
            series.MarkerStyle = MarkerStyle.Circle;
            series.Name = "T = " + outerEntry.Key + " (\u00b0C)";
            _chart.Series.Add(series);
            
            foreach (var innerEntry in outerEntry.Value)
            {
                var dataPoint = new DataPoint();
                dataPoint.SetValueXY(innerEntry.Key, innerEntry.Value);
                dataPoint.ToolTip = "T = " + outerEntry.Key + ", Pg = " + innerEntry.Key + ", σ = " + Math.Round(innerEntry.Value, 2);
                series.Points.Add(dataPoint);
                j++;
            }
            i++;
            j = 1;
        }
    }

    private void OnFormResize(object sender, EventArgs args)
    {
        _chart.Size = new Size(Size.Width, Size.Height - 40);
    }
}