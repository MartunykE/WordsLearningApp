using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using WordsLearningApp.TelegramBot.Models.Commands;
using WordsLearningApp.TelegramBot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using WordsLearningApp.BLL.Interfaces;
using WordsLearningApp.DAL.Models;
using AutoMapper;
using System.Timers;
using WordsLearningApp.BLL.DTO;

//delete
using WordsLearningApp.BLL.Services;
using Microsoft.AspNetCore.DataProtection;
using Telegram.Bot.Types.ReplyMarkups;

namespace WordsLearningApp.TelegramBot.Models
{
    public class BotSettings
    {
        public static string Key { get; set; }
    }
    public class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commandsList;
        public static IReadOnlyList<Command> Commands { get { return commandsList.AsReadOnly(); } }
        public static TelegramBotClient GetBotClientAsync(IWordsService wordsService, IUserService userService, IMapper mapper, ILanguageDictionary languageDictionary)
        {
            if (botClient != null)
            {
                return botClient;
            }

            ConfigureCommands(userService, wordsService, mapper, languageDictionary);
            wordsService.Timer.Elapsed += new ElapsedEventHandler((sender, args) => SendMessage(wordsService));

            botClient = new TelegramBotClient(BotSettings.Key);
            botClient.OnMessage += OnMessage;
            botClient.OnCallbackQuery += OnCallbackQuery;

            botClient.StartReceiving();

            return botClient;
        }

        private static async void OnMessage(object sender, MessageEventArgs args)
        {
            var message = args?.Message; 
            if (message == null)
            {
                return;
            }
            ExecuteCommand(message);

        }        

        private static void OnCallbackQuery(object sender, CallbackQueryEventArgs args)
        {
            string data = args.CallbackQuery.Data;
            if (data == null)
            {
                return;
            }
            Message message = args.CallbackQuery.Message;
            message.Text = data;
            ExecuteCommand(message);
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

        private static async void SendMessage(IWordsService wordsService)
        {
            var messagePackages = wordsService.GetSendMessagePackages();
            foreach (var message in messagePackages)
            {
                InlineKeyboardButton button = new InlineKeyboardButton() { Text = "Get Definition", CallbackData = $"/getDefinition {message.Message}" };
                InlineKeyboardMarkup markup = new InlineKeyboardMarkup(button);                
                await botClient.SendTextMessageAsync(message.ChatId, message.Message, replyMarkup: markup);
            }
        }

        private static void ConfigureCommands(IUserService userService, IWordsService wordsService, IMapper mapper, ILanguageDictionary languageDictionary)
        {
            commandsList = new List<Command>();
            commandsList.Add(new HelloComand(wordsService));
            commandsList.Add(new CreateWordCommand(wordsService));
            commandsList.Add(new StartCommand(userService));
            commandsList.Add(new SetShowTimeCommand(userService, mapper));
            commandsList.Add(new GetDefinitionCommand(languageDictionary));
        }
    }
}
