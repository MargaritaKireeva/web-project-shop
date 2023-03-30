using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebPL.Models
{
    public class UsersModel
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; }

        public static UsersModel FromEntity(User user)
        {
            return new UsersModel()
            {
                ID = user.ID,
                Login = user.Login,
                PhoneNumber = user.PhoneNumber,
                Name = user.Name,
                Birthday = user.Birthday,
                Password = user.Password,
            };
        }

    }
}
