using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.DAL.Interfaces
{
    public interface ICategoriesDAL
    {
        public Task<List<Category>> GetAllCategoriesAsync();
    }
}
