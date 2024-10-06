using System.Windows.Controls;
using CeramicAlloyCalculator.Researcher.Calculation.Dto;
using CeramicAlloyCalculator.Researcher.DataExport;

namespace CeramicAlloyCalculator;

public partial class GridForm : Form
{
    private readonly DataGridView _dataGridView;
    private readonly CalculationRequest _calculationRequest;
    private readonly CalculationResult _calculationResult;
    
    public GridForm(CalculationRequest calculationRequest, CalculationResult calculationResult)
    {
        InitializeComponent();

        _calculationRequest = calculationRequest;
        _calculationResult = calculationResult;

        Size = new Size(1200, 800);
        Text = "Таблица варьирования переменных";
        Resize += OnFormResize;

        var menuStrip = new MenuStrip();
        menuStrip.Dock = DockStyle.Top;
        var item = new ToolStripMenuItem()
        {
            Text = "В Excel файл...",
        };
        item.MouseUp += OnClickExportToExcelButton;
        menuStrip.Items.Add(new ToolStripMenuItem()
        {
            Text = "Экспорт",
            DropDownItems =
            {
                item
            }
        });
        Controls.Add(menuStrip);
        
        _dataGridView = new DataGridView();
        _dataGridView.ReadOnly = true;
        _dataGridView.RowHeadersVisible = false;
        _dataGridView.Location = new Point(0, 40);
        _dataGridView.Size = new Size(Size.Width - 25, Size.Height - 110);
        Controls.Add(_dataGridView);
        
        DrawGrid(calculationResult);
    }
    
    private void DrawGrid(CalculationResult calculationResult)
    {
        _dataGridView.Rows.Clear();
        _dataGridView.Columns.Clear();
        
        var emptyColumn = new DataGridViewColumn();
        emptyColumn.Name = "";
        emptyColumn.Width = 100;
        emptyColumn.CellTemplate = new DataGridViewButtonCell();
        _dataGridView.Columns.Add(emptyColumn);

        foreach (var pg in calculationResult.pgs)
        {
            var column = new DataGridViewColumn();
            column.Name = pg.ToString() + " атм.";
            column.Width = 100;
            column.CellTemplate = new DataGridViewButtonCell();
            _dataGridView.Columns.Add(column);
        }

        foreach (var t in calculationResult.ts)
        {
            var index = this._dataGridView.Rows.Add(1);
            
            _dataGridView.Rows[index].Cells[0].Value = t + " \u00b0C";
            _dataGridView.Rows[index].Cells[0].Style.BackColor = Color.White;
        }

        int i = 0;
        int j = 1;
        foreach (var outerEntry in calculationResult.sigmas)
        {
            foreach (var innerEntry in outerEntry.Value)
            {
                _dataGridView.Rows[i].Cells[j].Value = double.Round(innerEntry.Value, 2, MidpointRounding.AwayFromZero).ToString();
                j++;
            }
            i++;
            j = 1;
        }
    }
    
    private void OnFormResize(object sender, EventArgs args)
    {
        _dataGridView.Size = new Size(Size.Width - 25, Size.Height - 110);
    }

    private void OnClickExportToExcelButton(object sender, EventArgs eventArgs)
    {
        var saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Файлы Excel (*.xlsx)|*.xlsx";
        saveFileDialog.DefaultExt = "xlsx";
        saveFileDialog.AddExtension = true;
        var saveDialogResult = saveFileDialog.ShowDialog();
        if (saveDialogResult == DialogResult.OK)
        {
            var dataExporter = new DataExporter();
            dataExporter.SaveToExcelFile(saveFileDialog.FileName, _calculationRequest, _calculationResult);
        }
    }
}