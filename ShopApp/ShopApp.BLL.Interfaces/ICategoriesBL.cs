using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.BLL.Interfaces
{
    public interface ICategoriesBL
    {
        public  Task<List<Category>> GetAllCategoriesAsync();
    }
}
