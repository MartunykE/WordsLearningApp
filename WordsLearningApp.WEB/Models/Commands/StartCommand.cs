using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WordsLearningApp.WEB.Models.Commands
{
    public class StartCommand : Command
    {
        public override string Name => @"/start";
       

        public async override Task Execute(Message message, TelegramBotClient telegramBotClient)
        {
            var chatId = message.Chat.Id;
            await telegramBotClient.SendTextMessageAsync(chatId, "Hello", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
