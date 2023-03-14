using System;
using System.Collections.Generic;

#nullable disable

namespace ShopApp.DAL.DbModels
{
    public partial class OrderGood
    {
        public int OrderId { get; set; }
        public int GoodsId { get; set; }

        public virtual Good Goods { get; set; }
        public virtual Order Order { get; set; }
    }
}
