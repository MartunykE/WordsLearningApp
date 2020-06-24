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

namespace WordsLearningApp.WEB.Models
{
    public class Bot
    {
        static int a = 5;
        private static TelegramBotClient botClient;
        private static List<Command> commandsList;
        public static IReadOnlyList<Command> Commands { get { return commandsList.AsReadOnly(); } }
        public static TelegramBotClient GetBotClientAsync(IWordsService wordsService)
        {
            if (botClient != null)
            {
                return botClient;
            }
            commandsList = new List<Command>();
            commandsList.Add(new HelloComand(wordsService));
            commandsList.Add(new CreateWordCommand(wordsService));

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
            await botClient.SendTextMessageAsync(
                chatId: args.Message.Chat.Id,
                text: $"Hello from bot{++a}"
                );
        }

        private  static void ExecuteCommand(Message message)
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
    }
}
