using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.BLL.Interfaces;
using ShopApp.Entities;
using ShopApp.TelegramMessage;
using ShopApp.WebPL.Models;
using ShopApp.WebPL.RabbitMQ;
using ShopApp.WebPL.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShopApp.WebPL.Controllers
{
    public class UsersController : Controller
    {
        public IUsersBL _usersBL { get; set; }
        public TelegramBot telegramBot { get; set; }
        public RabbitMQClient rabbit { get; set; }
        public RedisStorageClient redis { get; set; }

        public UsersController(IUsersBL usersBL)
        {
            _usersBL = usersBL;
            telegramBot = new TelegramBot(_usersBL);
            rabbit = SingleRabbitAndRedis.Instance.Rabbit;
            redis = SingleRabbitAndRedis.Instance.Redis;

        }
        [HttpGet]
        public async Task<IActionResult> GetPassword(string login, string error, string _)
        {
            if (error == null) error = "";
            _ = "";
            ViewData["login"] = login;
            ViewData["errors"] = error;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetPassword(string login, string password)
        {           
            var user = redis.GetUser(login);
            if (user == null)
            {
                user = await _usersBL.GetByLogin(login);
                rabbit.Send($"Пользователь {login} извлечен из базы данных");
            }
            else rabbit.Send($"Пользователь {login} извлечен из кэша");
            if (user != null && user.Password == password)
            {
                var identity = new CustomUserIdentity(login, password);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                
                if (await _usersBL.IsAvailablePassword(password))
                {
                    await _usersBL.ReduceAttemptsCount(password);
                    redis.SetUser(login, user, 60);
                }
                else
                {                   
                    string error = "Количество попыток ввода этого пароля закончились. Запросите новый.";
                    rabbit.Send(error);
                    return RedirectToAction("GetPassword", "Users", new { login, error });
                }
            }
            rabbit.Send($"Выполнен вход: логин - {login} пароль - {password} ");
            return RedirectToAction("UserById", "Users", new { user.ID });
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UsersModel model)
        {
            if (!ModelState.IsValid)
            {
                string error = "Введены неккоректные данные!";
                ModelState.AddModelError("", error);
                rabbit.Send(error);
                return View(model);
            }
            User user = await _usersBL.GetByLogin(model.Login);
            if (user != null)
            {
                string error = "Пользователь с таким логином уже есть";
                ModelState.AddModelError("", error);
                rabbit.Send(error);
                return View(model);
            }
            user = new User
            {
                Login = model.Login,
                PhoneNumber = model.PhoneNumber,
                Name = model.Name,
                Birthday = model.Birthday,
            };
            await _usersBL.Add(user);
            string message = $"Зарегистрирован пользователь {model.Login}";
            rabbit.Send(message);
            return RedirectToAction("GetPassword", "Users", new { model.Login });
        }
        [Authorize]
        public async Task<IActionResult> UserById(int id)
        {
            var user = await _usersBL.GetByIDAsync(id);
            var usersModel = UsersModel.FromEntity(user);
            return View(usersModel);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string login)
        {
            var user = await _usersBL.GetByLogin(login);
            if (user != null)
            {
                return RedirectToAction("GetPassword", "Users", new { login });
            }
            else return RedirectToAction("Register", "Users");
            //return Redirect("/");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Users");
        }
    }
}

