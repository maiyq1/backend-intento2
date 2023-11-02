using Data.DbContext;
using Data.Model;

namespace Data;

public class UserData : IUserData
{
    private DatabaseDBContext _database;

    public UserData(DatabaseDBContext database)
    {
        _database = database;
    }
    public List<User> GetAll()
    {
        return _database.Users.ToList();
    }
}