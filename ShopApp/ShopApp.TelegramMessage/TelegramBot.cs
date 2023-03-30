using ShopApp.BLL.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShopApp.TelegramMessage
{
    public class TelegramBot
    {
        private static string token = "";
        private static  TelegramBotClient client;
        private static IUsersBL _usersBL { get; set; }
        //private static bool isStarting = false;

        public TelegramBot(IUsersBL usersBL)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving(Update, Error);
            _usersBL = usersBL;
        }


        //static void Main(string[] args)
        //{
        //    client = new TelegramBotClient(token);

        //    client.StartReceiving(Update, Error);

        //    Console.ReadLine();
        //}

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            switch (message.Text)
            {
                case "/start":
                    {
                        //Console.WriteLine(update.Message.Text);
                        await client.SendTextMessageAsync(update.Message.Chat.Id, "Привет, введите свой логин ");
                        //isStarting = true;                       
                        break;
                    }
                default:
                    {
                        string login = message.Text;
                        var user = await _usersBL.GetByLogin(login);
                        if (user != null)
                        {
                            string password = RandomString(12);
                            user.Password = password;
                            await client.SendTextMessageAsync(update.Message.Chat.Id, $"Ваш пароль: {password}. У вас 3 попытки, чтобы его ввести!");
                            await _usersBL.AddPassword(user);

                        }
                        else await client.SendTextMessageAsync(update.Message.Chat.Id, "Такого пользователя нет");
                        //await client.SendTextMessageAsync(update.Message.Chat.Id, "Введите команду /start для получения пароля");
                        break;
                    }
            }
            //Console.WriteLine("Work");
        }
        private static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}
