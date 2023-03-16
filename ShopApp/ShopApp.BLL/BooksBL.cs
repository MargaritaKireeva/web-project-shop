using ShopApp.BLL.Interfaces;
using ShopApp.DAL;
using ShopApp.DAL.Interfaces;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.BLL
{
    public class BooksBL : IBooksBL
    {
        public static IBooksDAL _booksDAL;
        public BooksBL(IBooksDAL booksDAL)
        {
            _booksDAL = booksDAL;
        }
        public async Task<List<Book>> GetAllBooksAsync(int CategoryID)
        {
            return await _booksDAL.GetAllBooksAsync(CategoryID);
        }
        public async Task<Book> GetByIDAsync(int BookID)
        {
            return await _booksDAL.GetByIDAsync(BookID);
        }
    }
}
