using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using WordsLearningApp.WEB.Models.Commands;
using WordsLearningApp.WEB;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace WordsLearningApp.WEB.Models
{
    public class Bot
    {
        static int a = 5;
        private static TelegramBotClient botClient;
        private static List<Command> commandsList;
        public static IReadOnlyList<Command> Commands { get { return commandsList.AsReadOnly(); } }
        public static TelegramBotClient GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }
            commandsList = new List<Command>();
            commandsList.Add(new StartCommand());
            commandsList.Add(new HelloComand());

            botClient = new TelegramBotClient("1230523330:AAHSjCV48j99JxZs-927QUK5dBj-481R424");
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
