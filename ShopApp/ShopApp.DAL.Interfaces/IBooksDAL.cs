using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.DAL.Interfaces
{
    public interface IBooksDAL
    {
        public Task<List<Book>> GetAllBooksAsync(int CategoryID);
        public Task<Book> GetByIDAsync(int BookID);
    }
}
