using System;
using System.Collections.Generic;
using System.Text;

namespace WordsLearningApp.DAL.Models
{
    public class UsersWords
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int WordId { get; set; }
        public Word Word { get; set; }
        

    }
}
