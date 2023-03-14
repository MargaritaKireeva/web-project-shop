using System;
using System.Collections.Generic;

#nullable disable

namespace ShopApp.DAL.DbModels
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Amount { get; set; }
        public string ReleaseYear { get; set; }
        public int PagesNumber { get; set; }
        public int AgeRestriction { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
