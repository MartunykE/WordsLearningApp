using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using WordsLearningApp.BLL.Interfaces;
namespace WordsLearningApp.TelegramBot.Models.Commands
{
    public class GetDefinitionCommand : Command
    {
        ILanguageDictionary languageDictionary;
        public override string Name => "getDefinition";
        public GetDefinitionCommand(ILanguageDictionary languageDictionary)
        {
            this.languageDictionary = languageDictionary;
        }
        public async override Task Execute(Message message, TelegramBotClient telegramBotClient)
        {
            string wordName = message.Text.Substring(message.Text.IndexOf(" ") + 1);
            string definition =  languageDictionary.GetWordDefinition(wordName);
            if (string.IsNullOrEmpty(definition))
            {
                definition = $"Can`t find the definition to word {wordName} in dictionary ";
            }

            await telegramBotClient.SendTextMessageAsync(message.Chat.Id, definition);
        }
    }
}
