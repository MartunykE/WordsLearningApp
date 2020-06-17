using System;
using System.Collections.Generic;
using System.Text;

namespace WordsLearningApp.DAL.Models
{
    class User
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public IEnumerable<Word> Words { get; set; }
    }
}
