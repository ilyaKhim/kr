using CeramicAlloyCalculator.Administrator.UserList;
using CeramicAlloyCalculator.Database;

namespace CeramicAlloyCalculator;

public partial class LoginForm : Form
{
    private Button _loginButton;
    private TextBox _loginInput;
    private TextBox _passwordInput;
    
    public LoginForm()
    {
        InitializeComponent();
        MinimizeBox = false;
        MaximizeBox = false;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Size = new Size(360, 340);
        Text = "Вход в систему";
        
        var loginLabel = new Label();
        loginLabel.Text = "Имя пользователя";
        loginLabel.Location = new Point(15, 10);
        loginLabel.Size = new Size(250, 40);
        Controls.Add(loginLabel);

        _loginInput = new TextBox();
        _loginInput.Location = new Point(15, 50);
        _loginInput.Size = new Size(300, 50);
        Controls.Add(_loginInput);
        
        var passwordLabel = new Label();
        passwordLabel.Text = "Пароль";
        passwordLabel.Location = new Point(15, 100);
        passwordLabel.Size = new Size(300, 40);
        Controls.Add(passwordLabel);
        
        _passwordInput = new TextBox();
        _passwordInput.Location = new Point(15, 140);
        _passwordInput.Size = new Size(300, 50);
        _passwordInput.PasswordChar = '*';
        _passwordInput.KeyUp += OnPasswordKeyUp;
        Controls.Add(_passwordInput);

        _loginButton = new Button();
        _loginButton.Text = "Войти";
        _loginButton.Location = new Point(15, 190);
        _loginButton.Size = new Size(300, 60);
        _loginButton.Click += OnLoginButtonClick;
        Controls.Add(_loginButton);
    }

    private void OnLoginButtonClick(object sender, EventArgs e)
    {
        Authorize();
    }

    private void Authorize()
    {
        SetLockFormStatus(true);
        
        var login = _loginInput.Text;
        var password = _passwordInput.Text;

        var authorizationManager = new AuthorizationManager(new UserListManager(new DatabaseApplicationContext()));
        var user = authorizationManager.authorize(login, password);
        _passwordInput.Text = "";
        
        if (user == null)
        {
            MessageBox.Show("Неправильная пара логин/пароль");
            SetLockFormStatus(false);
            return;
        }
        
        if (!user.is_admin)
        {
            var researcherForm = new ResearcherForm();
            researcherForm.Show();
            researcherForm.Closed += delegate
            {
                SetLockFormStatus(false);
            };
        } else {
            var administratorForm = new AdministratorForm();
            administratorForm.Show();
            administratorForm.Closed += delegate
            {
                SetLockFormStatus(false);
            };
        }
        Session.CurrentUserId = user.id;
    }

    private void OnPasswordKeyUp(object sender, KeyEventArgs eventArgs)
    {
        if (eventArgs.KeyCode == Keys.Enter)
        {
            Authorize();
        }
    }

    private void SetLockFormStatus(bool isLocked)
    {
        _loginButton.Enabled = !isLocked;
        _loginInput.Enabled = !isLocked;
        _passwordInput.Enabled = !isLocked;
    }
}