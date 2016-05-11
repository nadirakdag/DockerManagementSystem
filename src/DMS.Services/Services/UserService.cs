namespace DMS.Services.Services
{
    using Core;
    using Core.Entities;
    using Core.ServiceInterfaces;
    using Data;
    using Microsoft.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using System;

    public class UserService : IUserService
    {
        private DataContext _context;

        public UserService(DataContext context)
        {
            this._context = context;
        }

        public bool AddNewUser(User user)
        {
            _context.Users.Add(user);
            int count = _context.SaveChanges();
            return (count == 1 ? true : false);
        }

        public User GetUserById(int id)
        {
            return _context.Users.Include(x => x.Role).FirstOrDefault(x => x.UserId == id);
        }

        public bool DeleteUserById(int id)
        {
            User u = GetUserById(id);
            _context.Users.Remove(u);
            int count = _context.SaveChanges();
            return (count == 1 ? true : false);
        }

        public List<User> GetAllUser()
        {
            return _context.Users.Include(x => x.Role).ToList();
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public bool UserExist(string email, string password, out User user)
        {
            user = _context.Users.FirstOrDefault(x => x.EMail == email && x.Password == password);
            return user != null;
        }
    }
}
