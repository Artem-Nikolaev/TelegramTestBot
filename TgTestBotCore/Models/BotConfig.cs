using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TgTestBotCore.Models
{
    public static class BotConfig
    {
        private static IConfiguration _config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("botconfig.json")
            .Build();

        public static string ApiKey { get; } = _config["ApiKey"];
        public static string Name { get; } = _config["Name"];

        public static string UrlTemplate { get; } = _config["UrlTemplate"];
    }
}
