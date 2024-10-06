using CeramicAlloyCalculator.Administrator.UserList;
using CeramicAlloyCalculator.Database;
using CeramicAlloyCalculator.Database.Tables;

namespace CeramicAlloyCalculator;

public partial class EditUserForm : Form
{
    private readonly UserEntity _userEntity;
    private readonly AdministratorForm _administratorForm;

    private TextBox _nameInput, _usernameInput, _passwordInput;
    private CheckBox _isAdministratorInput;

    public EditUserForm(UserEntity userEntity, AdministratorForm administratorForm)
    {
        _userEntity = userEntity;
        _administratorForm = administratorForm;

        Text = "Создание/редактирование пользователя";
        MinimizeBox = false;
        MaximizeBox = false;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Size = new Size(400, 370);
        
        var nameLabel = new Label();
        nameLabel.Text = "ФИО";
        nameLabel.Location = new Point(15, 10);
        nameLabel.Size = new Size(250, 40);
        Controls.Add(nameLabel);
        
        _nameInput = new TextBox();
        _nameInput.Location = new Point(15, 50);
        _nameInput.Size = new Size(300, 50);
        _nameInput.Text = userEntity.name;
        Controls.Add(_nameInput);
        
        var usernameLabel = new Label();
        usernameLabel.Text = "Имя пользователя";
        usernameLabel.Location = new Point(15, 90);
        usernameLabel.Size = new Size(250, 40);
        Controls.Add(usernameLabel);
        
        _usernameInput = new TextBox();
        _usernameInput.Location = new Point(15, 130);
        _usernameInput.Size = new Size(300, 50);
        _usernameInput.Text = userEntity.username;
        Controls.Add(_usernameInput);
        
        var passwordLabel = new Label();
        passwordLabel.Text = "Пароль";
        passwordLabel.Location = new Point(15, 170);
        passwordLabel.Size = new Size(250, 40);
        Controls.Add(passwordLabel);
        
        _passwordInput = new TextBox();
        _passwordInput.Location = new Point(15, 210);
        _passwordInput.Size = new Size(300, 50);
        _passwordInput.Text = userEntity.password;
        _passwordInput.PasswordChar = '*';
        Controls.Add(_passwordInput);

        _isAdministratorInput = new CheckBox();
        _isAdministratorInput.Location = new Point(15, 250);
        _isAdministratorInput.Size = new Size(400, 50);
        _isAdministratorInput.Text = "Является администратором";
        _isAdministratorInput.Checked = userEntity.is_admin;
        Controls.Add(_isAdministratorInput);

        var saveButton = new Button();
        saveButton.Text = "Сохранить";
        saveButton.Location = new Point(15, 300);
        saveButton.Size = new Size(300, 60);
        saveButton.Click += OnSaveButtonClick;
        Controls.Add(saveButton);
        
        InitializeComponent();
    }

    private void OnSaveButtonClick(object sender, EventArgs eventArgs)
    {
        _userEntity.name = _nameInput.Text;
        _userEntity.username = _usernameInput.Text;
        _userEntity.password = _passwordInput.Text;
        _userEntity.is_admin = _isAdministratorInput.Checked;
        
        var userListManager = new UserListManager(new DatabaseApplicationContext());
        userListManager.SaveUser(_userEntity);
        
        _administratorForm.UpdateUserList();
        Close();
    }
}