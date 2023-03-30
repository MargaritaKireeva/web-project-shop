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
        private IUsersDAL _usersDAL;

        public UsersBL(IUsersDAL usersDal)
        {
            _usersDAL = usersDal;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _usersDAL.GetAllAsync();
        }

        public async Task<User> GetByIDAsync(int id)
        {
            return await _usersDAL.GetByIDAsync(id);
        }

        public async Task<User> GetByLogin(string login)
        {
            return await _usersDAL.GetByLogin(login);
        }
        public async Task<User> Add(User user)
        {
            return await _usersDAL.Add(user);
        }
        public async Task<User> AddPassword(User user)
        {
            return await _usersDAL.AddPassword(user);
        }
        public async Task<bool> IsAvailablePassword(string password)
        {
            return await _usersDAL.IsAvailablePassword(password);
        }
        public async Task ReduceAttemptsCount(string password)
        {
            await _usersDAL.ReduceAttemptsCount(password);
        }

    } 
}
