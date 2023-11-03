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

    public bool create(User user)
    {
        try
        {
            _database.Users.Add(user);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool update(User user, int id)
    {
        try
        {
            var UserUpdated = _database.Users.Where(t => t.Id == id).FirstOrDefault();

            UserUpdated.username = user.username;
            UserUpdated.password = user.password;

            _database.Users.Update(UserUpdated);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public User GetById(int id)
    {
        return _database.Users.Where(t => t.Id == id).FirstOrDefault();
    }
}