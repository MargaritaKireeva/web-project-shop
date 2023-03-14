using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities
{
    public class Book
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
    }
}
