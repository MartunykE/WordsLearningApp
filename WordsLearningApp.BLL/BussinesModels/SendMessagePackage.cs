using System;
using System.Collections.Generic;
using System.Text;

namespace WordsLearningApp.BLL.BussinesModels
{
    public class SendMessagePackage
    {
        public SendMessagePackage(long chatId, string message)
        {
            ChatId = chatId;
            Message = message;
        }
        public long ChatId { get; set; }
        public string Message { get; set; }
    }
}
