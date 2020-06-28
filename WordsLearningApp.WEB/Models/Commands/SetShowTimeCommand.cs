using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using WordsLearningApp.BLL.Interfaces;
using WordsLearningApp.BLL.DTO;

namespace WordsLearningApp.WEB.Models.Commands
{
    public class SetShowTimeCommand : Command
    {
        IUserService userService;
        public SetShowTimeCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public override string Name => "/SetShowTime";

        public async override Task Execute(Message message, TelegramBotClient telegramBotClient)
        {
            string timePattern = "([0-2]?[0-9]):[0-5][0-9]:[0-5][0-9]";
            string timeString = message.Text.Substring(message.Text.IndexOf(" "));
            DateTime showTime;
            if (Regex.IsMatch(timeString, timePattern))
            {
                showTime = DateTime.Parse(timeString);

                UserDTO userDTO = new UserDTO()
                {
                    ChatId = message.Chat.Id,
                    Name = message.Chat.Username,
                    ShowWordTime = showTime
                };

                userService.EditUser(userDTO);
                
                await telegramBotClient.SendTextMessageAsync(message.Chat.Id, "Time has been set ");
            }
            else
            {
                await telegramBotClient.SendTextMessageAsync(message.Chat.Id, "Incorrect time input. Time format is Hours:Minutes:Seconds. Example: /SetShowTime 15:30:00");
            }


        }
    }
}
