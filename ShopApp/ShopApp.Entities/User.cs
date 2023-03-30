using System;

namespace ShopApp.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; }
    }
}
