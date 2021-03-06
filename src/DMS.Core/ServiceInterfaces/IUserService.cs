﻿namespace DMS.Core.ServiceInterfaces
{
    using DMS.Core.Entities;
    using System.Collections.Generic;
    public interface IUserService
    {
        bool AddNewUser(User user);
        User GetUserById(int id);
        bool DeleteUserById(int id);
        List<User> GetAllUser();
        List<Role> GetRoles();
        void EditUser(User user);
        bool UserExist(string email, string password, out User user);
    }
}
