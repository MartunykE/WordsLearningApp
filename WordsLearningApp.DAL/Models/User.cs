using System;
using System.Collections.Generic;
using System.Text;

namespace WordsLearningApp.DAL.Models
{
   public class User
    {
        public int Id { get; set; }
        public long ChatId { get; set; }

        public string Name { get; set; }

       // public DateTime ShowWordSchedule { get; set; }
        public ICollection<Schedule> ShowWordSchedule { get; set; }

        public ICollection<Word> CommonWords { get; set; }
        public ICollection<Word> OftenWords { get; set; }
        public ICollection<Word> RareWords { get; set; }
    }
}
