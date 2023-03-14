using System;

namespace ShopApp.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public int ChatID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
