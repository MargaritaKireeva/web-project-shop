using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Web;

namespace TelegramBot
{
    class Program
    {
        private static string token = "";
        private static TelegramBotClient client;

        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);

            client.StartReceiving(Update, Error);

            Console.ReadLine();
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            switch (message.Text)
            {
                case "/start":
                    {
                        Console.WriteLine(update.Message.Text);
                        await client.SendTextMessageAsync(update.Message.Chat.Id, "Привет, введите команду /getpassword для получения пароля");
                        break;
                    }
                case "/getpassword":
                    {
                        Console.WriteLine(update.Message.Text);
                        await client.SendTextMessageAsync(update.Message.Chat.Id, $"Ваш пароль: {RandomString(12)}");
                        break;
                    }
                default:
                    {
                        Console.WriteLine(update.Message.Text);
                        await client.SendTextMessageAsync(update.Message.Chat.Id, "Введите команду /getpassword для получения пароля");
                        break;
                    }
            }
            Console.WriteLine("Work");
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
