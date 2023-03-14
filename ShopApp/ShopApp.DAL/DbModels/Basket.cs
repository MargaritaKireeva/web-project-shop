using System;
using System.Collections.Generic;

#nullable disable

namespace ShopApp.DAL.DbModels
{
    public partial class Basket
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime BasketCreationDate { get; set; }
        public decimal TotalCost { get; set; }

        public virtual Client Client { get; set; }
    }
}
