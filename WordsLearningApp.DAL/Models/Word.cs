using System;
using System.Collections.Generic;
using System.Text;

namespace WordsLearningApp.DAL.Models
{
    public class Word
    {
        public Word()
        {
            UserWords = new List<UsersWords>();
        }
        public int Id { get; set; }
        public string Name { get; set; }        
        public VisualRepresentation VisualRepresentation { get; set; } 
        public ICollection<UsersWords> UserWords { get; set; }
    }
}
