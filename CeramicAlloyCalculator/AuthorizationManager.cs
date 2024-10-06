using CeramicAlloyCalculator.Administrator.UserList;
using CeramicAlloyCalculator.Database.Tables;

namespace CeramicAlloyCalculator;

public class AuthorizationManager
{
    private readonly UserListManager _userListManager;

    public AuthorizationManager(UserListManager userListManager)
    {
        _userListManager = userListManager;
    }
    
    public UserEntity authorize(string username, string password)
    {
        return _userListManager.GetUserByUsernameAndPassword(username, password);
    }
}