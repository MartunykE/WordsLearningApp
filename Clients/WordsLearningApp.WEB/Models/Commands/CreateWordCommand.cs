using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using WordsLearningApp.BLL.DTO;
using WordsLearningApp.BLL.Interfaces;

namespace WordsLearningApp.TelegramBot.Models.Commands
{
    public class CreateWordCommand : Command
    {
        IWordsService wordsService;
        public CreateWordCommand(IWordsService wordsService)
        {
            this.wordsService = wordsService;
        }

        public override string Name => "/createWord";


        public async override Task Execute(Message message, TelegramBotClient telegramBotClient)
        {
            ChatId chatId = message.Chat.Id;
            string wordName = message.Text.Substring(message.Text.IndexOf(" ") + 1);            
            WordDTO wordDTO = new WordDTO();
            wordDTO.Name = wordName;
            wordDTO.UserChatId = message.Chat.Id;
            wordsService.CreateWord(wordDTO);
            await telegramBotClient.SendTextMessageAsync(chatId, "word created");
        }
    }
}
