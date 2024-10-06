using CeramicAlloyCalculator.Administrator.MaterialList;
using CeramicAlloyCalculator.Database;
using CeramicAlloyCalculator.Database.Tables;
using CeramicAlloyCalculator.Researcher.Calculation;
using CeramicAlloyCalculator.Researcher.Calculation.Dto;
using CeramicAlloyCalculator.Researcher.InputValidation.Dto;

namespace CeramicAlloyCalculator;

public partial class ResearcherForm : Form
{
    private readonly NumericUpDown _tMinInput, _tMaxInput, _tDeltaInput, _pgMinInput, _pgMaxInput, _pgDeltaInput;
    private readonly Button _calculateButton;
    private readonly ComboBox _materialSelect;
    private readonly MaterialListManager _materialListManager = new(new DatabaseApplicationContext());
    
    public ResearcherForm()
    {
        InitializeComponent();
        Text = "Интерфейс исследователя";
        Size = new Size(520, 410);
        MinimizeBox = false;
        MaximizeBox = false;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        
        var tMinLabel = new Label();
        tMinLabel.Text = "T min (\u00b0C)";
        tMinLabel.Location = new Point(15, 10);
        tMinLabel.Size = new Size(150, 40);
        Controls.Add(tMinLabel);
        
        _tMinInput = new NumericUpDown();
        _tMinInput.Location = new Point(15, 50);
        _tMinInput.Size = new Size(150, 50);
        _tMinInput.Minimum = -250;
        _tMinInput.Maximum = 9000;
        _tMinInput.Value = 1300;
        Controls.Add(_tMinInput);
        
        var tMaxLabel = new Label();
        tMaxLabel.Text = "T max (\u00b0C)";
        tMaxLabel.Location = new Point(175, 10);
        tMaxLabel.Size = new Size(150, 40);
        Controls.Add(tMaxLabel);
        
        _tMaxInput = new NumericUpDown();
        _tMaxInput.Location = new Point(175, 50);
        _tMaxInput.Size = new Size(150, 50);
        _tMaxInput.Minimum = -250;
        _tMaxInput.Maximum = 9000;
        _tMaxInput.Value = 1550;
        Controls.Add(_tMaxInput);
        
        var tDeltaLabel = new Label();
        tDeltaLabel.Text = "ΔT";
        tDeltaLabel.Location = new Point(335, 10);
        tDeltaLabel.Size = new Size(150, 40);
        Controls.Add(tDeltaLabel);
        
        _tDeltaInput = new NumericUpDown();
        _tDeltaInput.Location = new Point(335, 50);
        _tDeltaInput.Size = new Size(150, 50);
        _tDeltaInput.Minimum = 1;
        _tDeltaInput.Maximum = 100;
        _tDeltaInput.Value = 10;
        Controls.Add(_tDeltaInput);
        
        // 2nd row
        
        var pgMinLabel = new Label();
        pgMinLabel.Text = "Pg min (атм)";
        pgMinLabel.Location = new Point(15, 100);
        pgMinLabel.Size = new Size(150, 40);
        Controls.Add(pgMinLabel);
        
        _pgMinInput = new NumericUpDown();
        _pgMinInput.Location = new Point(15, 140);
        _pgMinInput.Size = new Size(150, 50);
        _pgMinInput.Minimum = 1;
        _pgMinInput.Maximum = 900;
        _pgMinInput.Value = 30;
        Controls.Add(_pgMinInput);
        
        var pgMaxLabel = new Label();
        pgMaxLabel.Text = "Pg max (атм)";
        pgMaxLabel.Location = new Point(175, 100);
        pgMaxLabel.Size = new Size(150, 40);
        Controls.Add(pgMaxLabel);
        
        _pgMaxInput = new NumericUpDown();
        _pgMaxInput.Location = new Point(175, 140);
        _pgMaxInput.Size = new Size(150, 50);
        _pgMaxInput.Minimum = 1;
        _pgMaxInput.Maximum = 900;
        _pgMaxInput.Value = 60;
        Controls.Add(_pgMaxInput);
        
        var pgDeltaLabel = new Label();
        pgDeltaLabel.Text = "ΔPg";
        pgDeltaLabel.Location = new Point(335, 100);
        pgDeltaLabel.Size = new Size(150, 40);
        Controls.Add(pgDeltaLabel);
        
        _pgDeltaInput = new NumericUpDown();
        _pgDeltaInput.Location = new Point(335, 140);
        _pgDeltaInput.Size = new Size(150, 50);
        _pgDeltaInput.Minimum = 1;
        _pgDeltaInput.Maximum = 10;
        _pgDeltaInput.Value = 2;
        Controls.Add(_pgDeltaInput);
        
        _materialSelect = new ComboBox();
        _materialSelect.Location = new Point(15, 200);
        _materialSelect.Size = new Size(470, 50);
        _materialSelect.DataSource = _materialListManager.GetMaterials();
        _materialSelect.DisplayMember = "name";
        Controls.Add(_materialSelect);

        _calculateButton = new Button();
        _calculateButton.Text = "Рассчитать";
        _calculateButton.Size = new Size(200, 60);
        _calculateButton.Location = new Point(15, 260);
        _calculateButton.Click += OnCalculateButtonClick;
        Controls.Add(_calculateButton);
    }

    public void OnCalculateButtonClick(object sender, EventArgs eventArgs)
    {
        SetLockStatus(true);
        
        var material = (MaterialEntity) _materialSelect.SelectedValue;
        
        var inputCoefficients = new InputCoefficients();
        inputCoefficients.tMin = (int) _tMinInput.Value;
        inputCoefficients.tMax = (int) _tMaxInput.Value;
        inputCoefficients.tDelta = (int) _tDeltaInput.Value;
        inputCoefficients.pgMin = (int) _pgMinInput.Value;
        inputCoefficients.pgMax = (int) _pgMaxInput.Value;
        inputCoefficients.pgDelta = (int) _pgDeltaInput.Value;

        var calculationRequest = new CalculationRequest();
        calculationRequest.InputCoefficients = inputCoefficients;
        calculationRequest.Material = material;

        var calculationManager = new CalculationManager();
        var calculationResult = calculationManager.Calculate(calculationRequest);

        var gridForm = new GridForm(calculationRequest, calculationResult);
        gridForm.Show();
        
        var chartForm = new ChartForm(calculationRequest, calculationResult);
        chartForm.Show();
        
        SetLockStatus(false);
    }

    

    private void SetLockStatus(bool isLocked)
    {
        _calculateButton.Enabled = !isLocked;
        _materialSelect.Enabled = !isLocked;
        _tMinInput.Enabled = !isLocked;
        _tMaxInput.Enabled = !isLocked;
        _tDeltaInput.Enabled = !isLocked;
        _pgMinInput.Enabled = !isLocked;
        _pgMaxInput.Enabled = !isLocked;
        _pgDeltaInput.Enabled = !isLocked;
    }
}