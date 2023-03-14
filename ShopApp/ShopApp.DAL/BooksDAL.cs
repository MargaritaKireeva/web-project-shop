using ShopApp.DAL.DbModels;
using ShopApp.DAL.Interfaces;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.DAL
{
    public class BooksDAL : IBooksDAL
    {
        public async Task<List<Entities.Book>> GetAllBooksAsync(int CategoryID)
        {
            using (var context = new DefaultDbContext())
            {
                return context.Books.ToList().Select(book => new Entities.Book()
                {
                    ID = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    Amount = book.Amount,
                    ReleaseYear = book.ReleaseYear,
                    PagesNumber = book.PagesNumber,
                    AgeRestriction = book.AgeRestriction,
                    Description = book.Description,
                    Picture = book.Picture,
                    Price = book.Price,
                    CategoryID = book.CategoryId
                }).Where(item => item.CategoryID == CategoryID).ToList();
            }
        }
    }
}
