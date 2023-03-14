using System;
using System.Collections.Generic;

#nullable disable

namespace ShopApp.DAL.DbModels
{
    public partial class DeliveryPoint
    {
        public DeliveryPoint()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string DeliveryAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
