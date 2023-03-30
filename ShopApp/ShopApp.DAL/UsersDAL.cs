using Microsoft.EntityFrameworkCore;
using ShopApp.DAL.DbModels;
using ShopApp.DAL.Interfaces;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.DAL
{
    public class UsersDAL : IUsersDAL
    {
        public async Task<List<Entities.User>> GetAllAsync()
        {
            using (var context = new DefaultDbContext())
            {
                return context.Users.Include(item => item.OneTimePasswords).ToList().Select(user => new Entities.User()
                {
                    ID = user.Id,
                    Login = user.Login,
                    PhoneNumber = user.PhoneNumber,
                    Name = user.Name,
                    Birthday = user.Birthday,
                    Password = user.OneTimePasswords.FirstOrDefault(item => item.UserId == user.Id).Password
                }).ToList();
            }
        }

        public async Task<Entities.User> GetByIDAsync(int id)
        {
            using (var context = new DefaultDbContext())
            {
                var user = context.Users.ToList().Where(user => user.Id == id).FirstOrDefault();
                return new Entities.User()
                {
                    ID = user.Id,
                    Login = user.Login,
                    PhoneNumber = user.PhoneNumber,
                    Name = user.Name,
                    Birthday = user.Birthday,
                    //Password = user.OneTimePasswords.FirstOrDefault(item => item.UserId == user.Id).Password
                };
            }
        }

        public async Task<Entities.User> Add(Entities.User user)
        {
            var dalItem = new DbModels.User()
            {
                Login = user.Login,
                PhoneNumber = user.PhoneNumber,
                Name = user.Name,
                Birthday = user.Birthday,
            };
            //var password = new DbModels.OneTimePassword()
            //{
            //    Password = user.Password,
            //    AttemptsCount = 3,
            //    UserId = user.ID,
            //    User = dalItem,
            //};
            using (var context = new DefaultDbContext())
            {
                context.Users.Add(dalItem);
                //context.OneTimePasswords.Add(password);
                await context.SaveChangesAsync();
            }
            user.ID = dalItem.Id;

            return user;
        }
        public async Task<Entities.User> AddPassword(Entities.User user)
        {
            using (var context = new DefaultDbContext())
            {
                var dalUser = context.Users.FirstOrDefault(item => item.Id == user.ID);
                var password = new DbModels.OneTimePassword()
                {
                    Password = user.Password,
                    AttemptsCount = 3,
                    UserId = user.ID,
                    User = dalUser,
                };
                context.OneTimePasswords.Add(password);
                await context.SaveChangesAsync();
                return user;
            }
        }
        public async Task<Entities.User> GetByLogin(string login)
        {
            using (var context = new DefaultDbContext())
            {
                var dalUser = context.Users.FirstOrDefault(item => item.Login == login);
                if (dalUser == null) return null;
                var dalPassword = context.OneTimePasswords.OrderBy(e => e.Id).LastOrDefault(item => item.UserId == dalUser.Id);
                if (dalPassword == null)
                    return new Entities.User()
                    {
                        ID = dalUser.Id,
                        Login = dalUser.Login,
                        PhoneNumber = dalUser.PhoneNumber,
                        Name = dalUser.Name,
                        Birthday = dalUser.Birthday,
                    };
                else return new Entities.User()
                {
                    ID = dalUser.Id,
                    Login = dalUser.Login,
                    PhoneNumber = dalUser.PhoneNumber,
                    Name = dalUser.Name,
                    Birthday = dalUser.Birthday,
                    Password = dalPassword.Password,
                };
            }
        }
        public async Task<bool> IsAvailablePassword(string password)
        {
            using (var context = new DefaultDbContext())
            {
                var dalPassword = context.OneTimePasswords.FirstOrDefault(item => item.Password == password);
                if (dalPassword != null)
                    return dalPassword.AttemptsCount > 0;
                else return false;

            }
        }
        public async Task ReduceAttemptsCount(string password)
        {
            using (var context = new DefaultDbContext())
            {
                var dalPassword = context.OneTimePasswords.FirstOrDefault(item => item.Password == password);
                if (dalPassword != null)
                    --dalPassword.AttemptsCount;
                await context.SaveChangesAsync();
            }
        }

    }
}
