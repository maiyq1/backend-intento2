using Data.Model;

namespace Data;

public interface IUserData
{
    public List<User> GetAll();

    bool create(User user);

    bool update(User user, int id);

    bool delete(int id);

    public User GetById(int id);
}