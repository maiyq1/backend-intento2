﻿using Data;
using Data.Model;

namespace Domain;

public class UserDomain : IUserDomain
{
    public IUserData _userData;

    public UserDomain(IUserData userData)
    {
        _userData = userData;
    }
    public bool create(User user)
    {
        if (user.username.Length < 8 || user.username.Length > 20 || user.password.Length < 8 )
            return false;
        return _userData.create(user);
    }

    public bool update(User user, int id)
    {
        var result = user.password;
        if (result == _userData.GetById(id).password)
        {
            return false;
        }
        else
        {
            return _userData.update(user, id);
        }
    }

    public bool delete(int id)
    {
        return _userData.delete(id);
    }
}