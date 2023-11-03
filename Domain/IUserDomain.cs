using Data.Model;

namespace Domain;

public interface IUserDomain
{
    bool create(User user);
    
    bool update(User user, int id);
}