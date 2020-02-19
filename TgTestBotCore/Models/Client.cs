using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using TgTestBotCore.Controllers;
using TgTestBotCore.Models.Commands;

namespace TgTestBotCore.Models
{
    public static class Client
    {
        private static ITelegramBotClient _instance;
        private static List<Command> _commands;

        public static IReadOnlyCollection<Command> Commands { get => _commands.AsReadOnly(); }

        public static async Task<ITelegramBotClient> GetInstance()
        {
            if (_instance != null)
            {
                return _instance;
            }

            _commands = new List<Command>
            {
                new HelloCommand()
            };

            _instance = new TelegramBotClient(BotConfig.ApiKey);

            var msgControllerMethod = typeof(MessageController).GetMethod(nameof(MessageController.Update));
            var msgUpdateRoute = (RouteAttribute) msgControllerMethod.GetCustomAttributes(typeof(RouteAttribute), true)[0]; 
            var hook = string.Format(BotConfig.UrlTemplate, msgUpdateRoute.Template);
            await _instance.SetWebhookAsync(hook);

            return _instance;
        }
    }
}
