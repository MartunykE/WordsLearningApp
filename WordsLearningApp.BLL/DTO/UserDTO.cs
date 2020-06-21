using System;
using System.Collections.Generic;
using System.Text;

namespace WordsLearningApp.BLL.DTO
{
    class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ShowFrequency ShowFrequency { get; set; }
        public int WordId { get; set; }
    }

    enum ShowFrequency
    {
        common,
        often,
        rare
    }
}
