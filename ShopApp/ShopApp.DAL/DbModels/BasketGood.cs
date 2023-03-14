using System;
using System.Collections.Generic;

#nullable disable

namespace ShopApp.DAL.DbModels
{
    public partial class BasketGood
    {
        public int BasketId { get; set; }
        public int GoodsId { get; set; }

        public virtual Basket Basket { get; set; }
        public virtual Good Goods { get; set; }
    }
}
