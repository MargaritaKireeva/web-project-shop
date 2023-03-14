using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.BLL.Interfaces
{
    public interface IBooksBL
    {
        public  Task<List<Book>> GetAllBooksAsync(int CategoryID);
    }
}
