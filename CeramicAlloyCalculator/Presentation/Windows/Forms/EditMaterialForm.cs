using System.Net.Mime;
using CeramicAlloyCalculator.Administrator.MaterialList;
using CeramicAlloyCalculator.Database;
using CeramicAlloyCalculator.Database.Tables;

namespace CeramicAlloyCalculator;

public partial class EditMaterialForm : Form
{
    private readonly MaterialEntity _materialEntity;
    private LogEntity _logEntity;
    private readonly AdministratorForm _administratorForm;
    private TextBox _nameInput;

    private readonly NumericUpDown _b0Input, _b1Input, _b2Input, _b3Input, _b4Input, _b5Input, _b6Input, _b7Input, _b8Input;
    private Button _saveButton;
    
    public EditMaterialForm(MaterialEntity materialEntity, AdministratorForm administratorForm)
    {
        _materialEntity = materialEntity;
        _administratorForm = administratorForm;

        InitializeComponent();
        Text = "Добавление/редактирование материала";
        MinimizeBox = false;
        MaximizeBox = false;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Size = new Size(360, 980);

        var nameLabel = new Label();
        nameLabel.Text = "Название материала";
        nameLabel.Location = new Point(15, 10);
        nameLabel.Size = new Size(250, 40);
        Controls.Add(nameLabel);
        
        _nameInput = new TextBox();
        _nameInput.Location = new Point(15, 50);
        _nameInput.Size = new Size(300, 50);
        _nameInput.Text = materialEntity.name;
        Controls.Add(_nameInput);
        
        var b0Label = new Label();
        b0Label.Text = "Коэффициент b0";
        b0Label.Location = new Point(15, 90);
        b0Label.Size = new Size(250, 40);
        Controls.Add(b0Label);
        
        _b0Input = new NumericUpDown();
        _b0Input.Location = new Point(15, 130);
        _b0Input.Size = new Size(300, 50);
        _b0Input.DecimalPlaces = 8;
        _b0Input.Minimum = -90000;
        _b0Input.Maximum = 90000;
        _b0Input.Value = Convert.ToDecimal(materialEntity.b0);
        Controls.Add(_b0Input);
        
        var b1Label = new Label();
        b1Label.Text = "Коэффициент b1";
        b1Label.Location = new Point(15, 170);
        b1Label.Size = new Size(250, 40);
        Controls.Add(b1Label);
        
        _b1Input = new NumericUpDown();
        _b1Input.Location = new Point(15, 210);
        _b1Input.Size = new Size(300, 50);
        _b1Input.DecimalPlaces = 8;
        _b1Input.Minimum = -90000;
        _b1Input.Maximum = 90000;
        _b1Input.Value = Convert.ToDecimal(materialEntity.b1);
        Controls.Add(_b1Input);
        
        var b2Label = new Label();
        b2Label.Text = "Коэффициент b2";
        b2Label.Location = new Point(15, 250);
        b2Label.Size = new Size(250, 40);
        Controls.Add(b2Label);
        
        _b2Input = new NumericUpDown();
        _b2Input.Location = new Point(15, 290);
        _b2Input.Size = new Size(300, 50);
        _b2Input.DecimalPlaces = 8;
        _b2Input.Minimum = -90000;
        _b2Input.Maximum = 90000;
        _b2Input.Value = Convert.ToDecimal(materialEntity.b2);
        Controls.Add(_b2Input);
        
        var b3Label = new Label();
        b3Label.Text = "Коэффициент b3";
        b3Label.Location = new Point(15, 330);
        b3Label.Size = new Size(250, 40);
        Controls.Add(b3Label);
        
        _b3Input = new NumericUpDown();
        _b3Input.Location = new Point(15, 370);
        _b3Input.Size = new Size(300, 50);
        _b3Input.DecimalPlaces = 8;
        _b3Input.Minimum = -90000;
        _b3Input.Maximum = 90000;
        _b3Input.Value = Convert.ToDecimal(materialEntity.b3);
        Controls.Add(_b3Input);
        
        var b4Label = new Label();
        b4Label.Text = "Коэффициент b4";
        b4Label.Location = new Point(15, 410);
        b4Label.Size = new Size(250, 40);
        Controls.Add(b4Label);
        
        _b4Input = new NumericUpDown();
        _b4Input.Location = new Point(15, 450);
        _b4Input.Size = new Size(300, 50);
        _b4Input.DecimalPlaces = 8;
        _b4Input.Minimum = -90000;
        _b4Input.Maximum = 90000;
        _b4Input.Value = Convert.ToDecimal(materialEntity.b4);
        Controls.Add(_b4Input);
        
        var b5Label = new Label();
        b5Label.Text = "Коэффициент b5";
        b5Label.Location = new Point(15, 490);
        b5Label.Size = new Size(250, 40);
        Controls.Add(b5Label);
        
        _b5Input = new NumericUpDown();
        _b5Input.Location = new Point(15, 530);
        _b5Input.Size = new Size(300, 50);
        _b5Input.DecimalPlaces = 8;
        _b5Input.Minimum = -90000;
        _b5Input.Maximum = 90000;
        _b5Input.Value = Convert.ToDecimal(materialEntity.b5);
        Controls.Add(_b5Input);
        
        var b6Label = new Label();
        b6Label.Text = "Коэффициент b6";
        b6Label.Location = new Point(15, 570);
        b6Label.Size = new Size(250, 40);
        Controls.Add(b6Label);
        
        _b6Input = new NumericUpDown();
        _b6Input.Location = new Point(15, 610);
        _b6Input.Size = new Size(300, 50);
        _b6Input.DecimalPlaces = 8;
        _b6Input.Minimum = -90000;
        _b6Input.Maximum = 90000;
        _b6Input.Value = Convert.ToDecimal(materialEntity.b6);
        Controls.Add(_b6Input);
        
        var b7Label = new Label();
        b7Label.Text = "Коэффициент b7";
        b7Label.Location = new Point(15, 650);
        b7Label.Size = new Size(250, 40);
        Controls.Add(b7Label);
        
        _b7Input = new NumericUpDown();
        _b7Input.Location = new Point(15, 690);
        _b7Input.Size = new Size(300, 50);
        _b7Input.DecimalPlaces = 8;
        _b7Input.Minimum = -90000;
        _b7Input.Maximum = 90000;
        _b7Input.Value = Convert.ToDecimal(materialEntity.b7);
        Controls.Add(_b7Input);
        
        var b8Label = new Label();
        b8Label.Text = "Коэффициент b8";
        b8Label.Location = new Point(15, 730);
        b8Label.Size = new Size(250, 40);
        Controls.Add(b8Label);
        
        _b8Input = new NumericUpDown();
        _b8Input.Location = new Point(15, 770);
        _b8Input.Size = new Size(300, 50);
        _b8Input.DecimalPlaces = 8;
        _b8Input.Minimum = -90000;
        _b8Input.Maximum = 90000;
        _b8Input.Value = Convert.ToDecimal(materialEntity.b8);
        Controls.Add(_b8Input);

        _saveButton = new Button();
        _saveButton.Text = "Сохранить";
        _saveButton.Location = new Point(15, 830);
        _saveButton.Size = new Size(300, 60);
        _saveButton.Click += OnSaveButtonClick;
        Controls.Add(_saveButton);
    }

    private void OnSaveButtonClick(object sender, EventArgs eventArgs)
    {
        _materialEntity.name = _nameInput.Text;
        _materialEntity.b0 = (double) _b0Input.Value;
        _materialEntity.b1 = (double) _b1Input.Value;
        _materialEntity.b2 = (double) _b2Input.Value;
        _materialEntity.b3 = (double) _b3Input.Value;
        _materialEntity.b4 = (double) _b4Input.Value;
        _materialEntity.b5 = (double) _b5Input.Value;
        _materialEntity.b6 = (double) _b6Input.Value;
        _materialEntity.b7 = (double) _b7Input.Value;
        _materialEntity.b8 = (double) _b8Input.Value;

        var materialListManager = new MaterialListManager(new DatabaseApplicationContext());
        materialListManager.SaveMaterial(_materialEntity);

        _logEntity = new LogEntity();
        _logEntity.user_id = Session.CurrentUserId;
        _logEntity.material_id = _materialEntity.id;
        _logEntity.Event = "Создание нового материала " + _materialEntity.name;
        var logManager = new LogManager(new DatabaseApplicationContext());
        logManager.SaveLog(_logEntity);
        
        _administratorForm.UpdateMaterialsList();
        
        Close();
    }
}