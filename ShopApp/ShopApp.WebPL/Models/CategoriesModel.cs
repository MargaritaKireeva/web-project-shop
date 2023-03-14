using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebPL.Models
{
    public class CategoriesModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static CategoriesModel FromEntity(Category categories)
        {
            return new CategoriesModel
            {
                ID = categories.ID,
                Name = categories.Name
            };
        }
    }
}
