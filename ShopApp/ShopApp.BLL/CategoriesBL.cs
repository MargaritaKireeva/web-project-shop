using ShopApp.BLL.Interfaces;
using ShopApp.DAL;
using ShopApp.DAL.Interfaces;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.BLL
{
    public class CategoriesBL : ICategoriesBL
    {
        public static ICategoriesDAL _categoriesDAL;
        public CategoriesBL(ICategoriesDAL categoriesDAL)
        {
            _categoriesDAL = categoriesDAL;
        }
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _categoriesDAL.GetAllCategoriesAsync();
        }
    }
}
