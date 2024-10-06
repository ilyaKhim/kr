using CeramicAlloyCalculator.Database;
using CeramicAlloyCalculator.Database.Tables;

namespace CeramicAlloyCalculator.Administrator.UserList;

public class UserListManager
{
    private readonly DatabaseApplicationContext _dbContext;

    public UserListManager(DatabaseApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<UserEntity> GetUserList()
    {
        return _dbContext.users.ToList();
    }

    public void SaveUser(UserEntity userEntity)
    {
        if (userEntity.id != null) {
            _dbContext.users.Update(userEntity);
        } else {
            _dbContext.users.Add(userEntity);
        }

        _dbContext.SaveChanges();
    }

    public void DeleteUser(UserEntity userEntity)
    {
        _dbContext.users.Remove(userEntity);
        _dbContext.SaveChanges();
    }

    public UserEntity GetUserByUsernameAndPassword(string username, string password)
    {
        var container = _dbContext.users.Where(u => u.username == username && u.password == password);
        if (container.Count() == 0)
        {
            return null;
        }

        return container.First();
    }
}