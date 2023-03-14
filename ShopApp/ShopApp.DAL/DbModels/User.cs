using System;
using System.Collections.Generic;

#nullable disable

namespace ShopApp.DAL.DbModels
{
    public partial class User
    {
        public User()
        {
            OneTimePasswords = new HashSet<OneTimePassword>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public int ChatId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public virtual ICollection<OneTimePassword> OneTimePasswords { get; set; }
    }
}
