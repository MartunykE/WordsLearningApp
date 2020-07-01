using System;
using System.Collections.Generic;
using System.Text;

namespace WordsLearningApp.DAL.Models
{
   public class User
    {

        public User()
        {
            CommonUserWords = new List<UsersWords>();
            OftenUserWords = new List<UsersWords>();
            RareUserWords = new List<UsersWords>();
        }
        public int Id { get; set; }
        public long ChatId { get; set; }

        public string Name { get; set; }

        public DateTime StartSendWordsTime { get; set; }
        public DateTime FinishSendWordsTime { get; set; }
        //public ICollection<Schedule> ShowWordSchedule { get; set; }

        public ICollection<UsersWords> CommonUserWords { get; set; }
        public ICollection<UsersWords> OftenUserWords { get; set; }
        public ICollection<UsersWords> RareUserWords { get; set; }
    }
}
