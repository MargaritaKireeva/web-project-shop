using ShopApp.BLL.Interfaces;
using ShopApp.DAL;
using ShopApp.DAL.Interfaces;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.BLL
{
    public class UsersBL : IUsersBL
    {
        public static IUsersDAL _usersDAL;
        public UsersBL()
        {
            _usersDAL = new UsersDAL();
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _usersDAL.GetAllUsersAsync();
        }
    }
}
