using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebPL.Models
{
    public class BooksModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Amount { get; set; }
        public string ReleaseYear { get; set; }
        public int PagesNumber { get; set; }
        public int AgeRestriction { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public static BooksModel FromEntity(Book book)
        {
            return new BooksModel
            {
                ID = book.ID,
                Name = book.Name,
                Author = book.Author,
                Amount = book.Amount,
                ReleaseYear = book.ReleaseYear,
                PagesNumber = book.PagesNumber,
                AgeRestriction = book.AgeRestriction,
                Description = book.Description,
                Picture = book.Picture,
                Price = book.Price,
                CategoryID = book.CategoryID
            };
        }
    }
}
