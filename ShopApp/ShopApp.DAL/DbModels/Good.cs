using System;
using System.Collections.Generic;

#nullable disable

namespace ShopApp.DAL.DbModels
{
    public partial class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string ItemDescription { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
    }
}
