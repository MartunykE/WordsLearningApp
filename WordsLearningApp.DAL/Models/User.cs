using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordsLearningApp.DAL.Models
{
   public class User
    {

        public User()
        {
            UserWords = new List<UsersWords>();            
        }
        public int Id { get; set; }
        public long? ChatId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public DateTime StartSendWordsTime { get; set; }
        public DateTime FinishSendWordsTime { get; set; }

        public ICollection<UsersWords> UserWords { get; set; }
       
    }
}
