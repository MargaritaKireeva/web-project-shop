using ShopApp.DAL.DbModels;
using ShopApp.DAL.Interfaces;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.DAL
{
    public class CategoriesDAL : ICategoriesDAL
    {

        public async Task<List<Entities.Category>> GetAllCategoriesAsync()
        {
            using (var context = new DefaultDbContext())
            {
                return context.Categories.ToList().Select(item => new Entities.Category()
                {
                    ID = item.Id,
                    Name = item.Name
                }).ToList();
            }
        }
    }
}
