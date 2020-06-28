using WordsLearningApp.BLL.BussinesModels;
using System;

namespace WordsLearningApp.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public long ChatId { get; set; }
        public string Name { get; set; }
        public ShowFrequency ShowFrequency { get; set; }
        public int WordId { get; set; }

        public DateTime ShowWordTime { get; set; }

    }


}
