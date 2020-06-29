using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using WordsLearningApp.WEB.Models.Commands;
using WordsLearningApp.WEB;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using WordsLearningApp.BLL.Interfaces;
using WordsLearningApp.DAL.Models;
using AutoMapper;
using System.Timers;
using WordsLearningApp.BLL.DTO;

//delete
using WordsLearningApp.BLL.Services;

namespace WordsLearningApp.WEB.Models
{
    public class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commandsList;
        private static WordsService wordsService2;
        public static IReadOnlyList<Command> Commands { get { return commandsList.AsReadOnly(); } }
        public static TelegramBotClient GetBotClientAsync(IWordsService wordsService, IUserService userService, IMapper mapper)
        {
            if (botClient != null)
            {
                return botClient;
            }

            ConfigureCommands(userService, wordsService, mapper);
            wordsService2 = (WordsService)wordsService;
            //wordsService.Timer.Elapsed += new ElapsedEventHandler(SendMessage);

            botClient = new TelegramBotClient(BotSettings.Key);
            botClient.OnMessage += OnMessage;
            botClient.StartReceiving();

            return botClient;
        }

        private static async void OnMessage(object sender, MessageEventArgs args)
        {
            var message =  args?.Message;
            if (message == null)
            {
                return;
            }
            ExecuteCommand(message);
            //await botClient.SendTextMessageAsync(
            //    chatId: args.Message.Chat.Id,
            //    text: $"Hello from bot{++a}"
            //    );
        }

        private static void ExecuteCommand(Message message)
        {
            foreach (var command in commandsList)
            {
                if (command.Contains(message))
                {
                    command.Execute(message, botClient);
                    break;
                }
            }
        }

        private static void SendMessage(object sender, ElapsedEventArgs e)
        {
            WordDTO wordDTO = wordsService2.InitializeTimer();
            botClient.SendTextMessageAsync(444601783, wordDTO.Name);
        }

        private static void ConfigureCommands(IUserService userService, IWordsService wordsService, IMapper mapper)
        {
            commandsList = new List<Command>();
            commandsList.Add(new HelloComand(wordsService));
            commandsList.Add(new CreateWordCommand(wordsService));
            commandsList.Add(new StartCommand(userService));
            commandsList.Add(new SetShowTimeCommand(userService, mapper));
        }
    }
}
