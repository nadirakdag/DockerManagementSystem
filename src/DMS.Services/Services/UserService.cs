namespace DMS.Services.Services
{
    using Core;
    using Core.Entities;
    using Core.ServiceInterfaces;
    using Data;
    using Microsoft.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;

    public class UserService : IUserService
    {
        private DataContext context;

        public UserService(DataContext context)
        {
            this.context = context;
        }

        public bool AddNewUser(User user)
        {
            context.Users.Add(user);
            int count = context.SaveChanges();
            return (count == 1 ? true : false);
        }

        public User GetUserById(int id)
        {
            return context.Users.Include(x => x.Role).FirstOrDefault(x => x.UserId == id);
        }

        public bool DeleteUserById(int id)
        {
            User u = GetUserById(id);
            context.Users.Remove(u);
            int count = context.SaveChanges();
            return (count == 1 ? true : false);
        }
        
        public List<User> GetAllUser(){
            return context.Users.Include(x=>x.Role).ToList();
        }
        
        public List<Role> GetRoles(){
            return context.Roles.ToList();
        }
    }
}
