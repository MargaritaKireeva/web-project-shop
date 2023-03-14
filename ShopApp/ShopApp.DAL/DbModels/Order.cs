using System;
using System.Collections.Generic;

#nullable disable

namespace ShopApp.DAL.DbModels
{
    public partial class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalCost { get; set; }
        public int DeliveryPointId { get; set; }

        public virtual Client Client { get; set; }
        public virtual DeliveryPoint DeliveryPoint { get; set; }
    }
}
