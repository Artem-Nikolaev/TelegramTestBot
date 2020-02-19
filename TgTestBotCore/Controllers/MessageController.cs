using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TgTestBotCore.Models;

namespace TgTestBotCore.Controllers
{
    public class MessageController : ControllerBase
    {
        [Route(@"api/update")]
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = Client.Commands;
            var msg = update.Message;
            var client = await Client.GetInstance();

            var command = commands.FirstOrDefault(x => x.Contains(msg.Text));
            if (command != null)
            {
                command.ExecuteAsync(msg, client);
            }

            return Ok();
        }
    }
}