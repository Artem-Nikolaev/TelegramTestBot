using Telegram.Bot;
using Telegram.Bot.Types;

namespace TgTestBotCore.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract void ExecuteAsync(Message msg, ITelegramBotClient client);

        public bool Contains(string command)
        {
            return command.Contains(this.Name) && command.Contains(BotConfig.Name);
        }
    }
}
