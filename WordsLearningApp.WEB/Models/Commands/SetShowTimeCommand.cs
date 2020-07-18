using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using WordsLearningApp.BLL.Interfaces;
using WordsLearningApp.BLL.DTO;
using AutoMapper;

namespace WordsLearningApp.TelegramBot.Models.Commands
{
    public class SetShowTimeCommand : Command
    {
        IUserService userService;
        IMapper mapper;
        List<string> commandNames;
        public SetShowTimeCommand(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
            commandNames = new List<string>();
            commandNames.Add("StartShowTime");
            commandNames.Add("FinishShowTime");
        }

        public override string Name => commandNames.FirstOrDefault();


        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            {
                return false;
            }

            foreach (var name in commandNames)
            {
                if (message.Text.Contains(name))
                {
                    return true;
                }
            }

            return false;

        }

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
                };
                if (message.Text.Contains("/StartShowTime"))
                {
                    userDTO.StartSendWordTime = showTime;
                }
                else
                {
                    userDTO.FinishSendWordTime = showTime;
                }

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
