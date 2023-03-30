using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.DAL.Interfaces
{
    public interface IUsersDAL
    {
        Task<List<User>> GetAllAsync();

        Task<User> GetByIDAsync(int id);

        Task<User> GetByLogin(string login);
        Task<User> Add(User user);
        Task<User> AddPassword(User user);
        Task<bool> IsAvailablePassword(string password);
        Task ReduceAttemptsCount(string password);

    }
}
