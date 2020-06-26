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
        public IEnumerable<Word> CommonWords { get; set; }
        public IEnumerable<Word> OftenWords { get; set; }
        public IEnumerable<Word> RareWords { get; set; }
    }
}
