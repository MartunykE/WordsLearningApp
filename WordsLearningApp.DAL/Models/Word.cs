using System;
using System.Collections.Generic;
using System.Text;

namespace WordsLearningApp.DAL.Models
{
    class Word
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, string> Definition { get; set; }
        public Dictionary<int, string> Translate { get; set; }
        public ShowFrequency ShowFrequency { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
