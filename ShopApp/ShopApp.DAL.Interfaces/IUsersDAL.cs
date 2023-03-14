using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.DAL.Interfaces
{
    public interface IUsersDAL
    {
        public Task<List<User>> GetAllUsersAsync();
    }
}
