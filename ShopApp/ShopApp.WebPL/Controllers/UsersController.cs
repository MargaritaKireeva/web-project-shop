using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.BLL.Interfaces;
using ShopApp.Entities;
using ShopApp.TelegramMessage;
using ShopApp.WebPL.Models;
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

        public UsersController(IUsersBL usersBL)
        {
            _usersBL = usersBL;
            
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
            var user = await _usersBL.GetByLogin(login);
            telegramBot = new TelegramBot(_usersBL);
            if (user != null && user.Password == password)
            {
                var identity = new CustomUserIdentity(login, password);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                if (await _usersBL.IsAvailablePassword(password))
                {
                    await _usersBL.ReduceAttemptsCount(password);
                }
                else
                {

                    string error = "Количество попыток ввода этого пароля закончились. Запросите новый.";
                    return RedirectToAction("GetPassword", "Users", new { login, error });
                }
            }
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
                ModelState.AddModelError("", "Введены неккоректные данные!");
                return View(model);
            }
            User user = await _usersBL.GetByLogin(model.Login);
            if (user != null)
            {
                ModelState.AddModelError("", "Пользователь с таким логином уже есть");
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
    }
}

