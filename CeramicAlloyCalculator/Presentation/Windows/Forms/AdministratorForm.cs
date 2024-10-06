using CeramicAlloyCalculator.Administrator.MaterialList;
using CeramicAlloyCalculator.Administrator.UserList;
using CeramicAlloyCalculator.Database;
using CeramicAlloyCalculator.Database.Tables;

namespace CeramicAlloyCalculator;

public partial class AdministratorForm : Form
{
    private readonly ListBox _materialList = new ListBox();
    private readonly Button _newMaterialButton = new Button();
    private readonly Button _editMaterialButton = new Button();
    private readonly Button _deleteMaterialButton = new Button();
    
    private readonly ListBox _userList = new ListBox();
    private readonly Button _newUserButton = new Button();
    private readonly Button _editUserButton = new Button();
    private readonly Button _deleteUserButton = new Button();
    
    public AdministratorForm()
    {
        InitializeComponent();
        Height = 860;
        Width = 700;
        MinimizeBox = false;
        MaximizeBox = false;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        
        var tabControl = new TabControl();
        tabControl.Size = new Size(1000, 1000);
        tabControl.Location = new Point(0, 0);
        Controls.Add(tabControl);
        
        var materialsTabPage = new TabPage()
        {
            Text = "Материалы"
        };
        tabControl.TabPages.Add(materialsTabPage);
        
        var userTabPage = new TabPage()
        {
            Text = "Пользователи"
        };
        tabControl.TabPages.Add(userTabPage);
        
        DefineMaterialsTab(materialsTabPage);
        DefineUsersTab(userTabPage);
    }

    private void DefineMaterialsTab(TabPage tabPage)
    {
        var materialListLabel = new Label();
        materialListLabel.Text = "Список материалов";
        materialListLabel.Location = new Point(15, 10);
        materialListLabel.Size = new Size(250, 40);
        tabPage.Controls.Add(materialListLabel);
        
        _materialList.DisplayMember = "name";
        _materialList.Size = new Size(300, 700);
        _materialList.Location = new Point(15, 50);
        tabPage.Controls.Add(_materialList);
        
        _newMaterialButton.Text = "Добавить";
        _newMaterialButton.Size = new Size(250, 60);
        _newMaterialButton.Location = new Point(320, 50);
        _newMaterialButton.Click += OnNewMaterialMaterialButtonClick;
        tabPage.Controls.Add(_newMaterialButton);
        
        _editMaterialButton.Text = "Редактировать";
        _editMaterialButton.Size = new Size(250, 60);
        _editMaterialButton.Location = new Point(320, 120);
        _editMaterialButton.Click += OnEditMaterialMaterialButtonClick;
        tabPage.Controls.Add(_editMaterialButton);
        
        _deleteMaterialButton.Text = "Удалить";
        _deleteMaterialButton.Size = new Size(250, 60);
        _deleteMaterialButton.Location = new Point(320, 190);
        _deleteMaterialButton.Click += OnDeleteMaterialMaterialButtonClick;
        tabPage.Controls.Add(_deleteMaterialButton);
        
        UpdateMaterialsList();
    }

    private void DefineUsersTab(TabPage tabPage)
    {
        var userListLabel = new Label();
        userListLabel.Text = "Список пользователей";
        userListLabel.Location = new Point(15, 10);
        userListLabel.Size = new Size(250, 40);
        tabPage.Controls.Add(userListLabel);
        
        _userList.DisplayMember = "name";
        _userList.Size = new Size(300, 700);
        _userList.Location = new Point(15, 50);
        tabPage.Controls.Add(_userList);
        
        _newUserButton.Text = "Добавить";
        _newUserButton.Size = new Size(250, 60);
        _newUserButton.Location = new Point(320, 50);
        _newUserButton.Click += OnNewUserButtonClick;
        tabPage.Controls.Add(_newUserButton);
        
        _editUserButton.Text = "Редактировать";
        _editUserButton.Size = new Size(250, 60);
        _editUserButton.Location = new Point(320, 120);
        _editUserButton.Click += OnEditUserButtonClick;
        tabPage.Controls.Add(_editUserButton);
        
        _deleteUserButton.Text = "Удалить";
        _deleteUserButton.Size = new Size(250, 60);
        _deleteUserButton.Location = new Point(320, 190);
        _deleteUserButton.Click += OnDeleteUserButtonClick;
        tabPage.Controls.Add(_deleteUserButton);
        
        UpdateMaterialsList();
        UpdateUserList();
    }

    public void UpdateMaterialsList()
    {
        var materialListManager = new MaterialListManager(new DatabaseApplicationContext());
        var materials = materialListManager.GetMaterials();

        _materialList.DataSource = materials;
    }

    public void UpdateUserList()
    {
        var userListManager = new UserListManager(new DatabaseApplicationContext());
        var users = userListManager.GetUserList();

        _userList.DataSource = users;
    }

    private void OnNewMaterialMaterialButtonClick(object sender, EventArgs eventArgs)
    {
        var material = new MaterialEntity();
        var editMaterialForm = new EditMaterialForm(material, this);
        editMaterialForm.Show();
    }

    private void OnEditMaterialMaterialButtonClick(object sender, EventArgs eventArgs)
    {
        var material = (MaterialEntity) _materialList.SelectedValue;
        if (material != null)
        {
            var editMaterialForm = new EditMaterialForm(material, this);
            editMaterialForm.Show();
        }
    }

    private void OnDeleteMaterialMaterialButtonClick(object sender, EventArgs eventArgs)
    {
        var material = (MaterialEntity) _materialList.SelectedValue;
        if (material != null)
        {
            var materialListManager = new MaterialListManager(new DatabaseApplicationContext());
            materialListManager.DeleteMaterial(material);
            
            UpdateMaterialsList();
        }
    }

    private void OnNewUserButtonClick(object sender, EventArgs eventArgs)
    {
        var user = new UserEntity();
        var editUserForm = new EditUserForm(user, this);
        editUserForm.Show();
    }

    private void OnEditUserButtonClick(object sender, EventArgs eventArgs)
    {
        var user = (UserEntity) _userList.SelectedValue;
        if (user != null)
        {
            var editUserForm = new EditUserForm(user, this);
            editUserForm.Show();
        }
    }

    private void OnDeleteUserButtonClick(object sender, EventArgs eventArgs)
    {
        var user = (UserEntity) _userList.SelectedValue;
        if (user != null)
        {
            var userListManager = new UserListManager(new DatabaseApplicationContext());
            userListManager.DeleteUser(user);

            UpdateUserList();
        }
    }
}