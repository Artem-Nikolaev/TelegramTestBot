using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TgTestBotCore.Models;

namespace TgTestBotCore.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            if (string.IsNullOrEmpty(BotConfig.ApiKey))
            {
                return "Bot API key is not provided";
            }
            return "Bot is running";
        }
    }
}
