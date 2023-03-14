using System;
using System.Collections.Generic;

#nullable disable

namespace ShopApp.DAL.DbModels
{
    public partial class OrderBook
    {
        public int OrderId { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}
