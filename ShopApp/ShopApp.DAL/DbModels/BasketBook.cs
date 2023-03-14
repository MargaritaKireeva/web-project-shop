using System;
using System.Collections.Generic;

#nullable disable

namespace ShopApp.DAL.DbModels
{
    public partial class BasketBook
    {
        public int BasketId { get; set; }
        public int BookId { get; set; }

        public virtual Basket Basket { get; set; }
        public virtual Book Book { get; set; }
    }
}
