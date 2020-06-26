using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using WordsLearningApp.BLL.DTO;
using WordsLearningApp.BLL.Interfaces;

namespace WordsLearningApp.WEB.Models.Commands
{
    public class StartCommand : Command
    {
        IUserService userService;

        public override string Name => "/start";


        public StartCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public async override Task Execute(Message message, TelegramBotClient telegramBotClient)
        {
            UserDTO userDTO = new UserDTO()
            {
                ChatId = message.Chat.Id,
                Name = message.Chat.Username,
            };

            userService.CreateUser(userDTO);    
            
        }
    }
}
