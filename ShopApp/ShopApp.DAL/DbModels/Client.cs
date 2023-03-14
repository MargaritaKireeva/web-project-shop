using System;
using System.Collections.Generic;

#nullable disable

namespace ShopApp.DAL.DbModels
{
    public partial class Client
    {
        public Client()
        {
            Baskets = new HashSet<Basket>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
