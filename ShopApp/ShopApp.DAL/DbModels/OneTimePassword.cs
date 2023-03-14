using System;
using System.Collections.Generic;

#nullable disable

namespace ShopApp.DAL.DbModels
{
    public partial class OneTimePassword
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public int AttemptsCount { get; set; }

        public virtual User User { get; set; }
    }
}
