using ShopApp.DAL.Interfaces;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.DAL
{
    public class UsersDAL : IUsersDAL
    {
        public static List<User> _users = new List<User>();

        public async Task<List<User>> GetAllUsersAsync()
        {
            return _users;
        }
    }
}
