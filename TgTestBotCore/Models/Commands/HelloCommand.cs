using Telegram.Bot;
using Telegram.Bot.Types;

namespace TgTestBotCore.Models.Commands
{
    public class HelloCommand : Command
    {
        public override string Name => "hello";

        public override async void ExecuteAsync(Message msg, ITelegramBotClient client)
        {
            var chatId = msg.Chat.Id;
            var msgId = msg.MessageId;
            
            await client.SendTextMessageAsync(chatId, "Hi there", replyToMessageId: msgId);
        }
    }
}
