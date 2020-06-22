using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WordsLearningApp.WEB.Models.Commands
{
    public class HelloComand : Command
    {
        public override string Name => "Hello";

        public override async Task Execute(Message message, TelegramBotClient telegramBotClient)
        {
            var chatId = message.Chat.Id;
            await telegramBotClient.SendTextMessageAsync(chatId, "A yo from hello command");
        }
    }
}
